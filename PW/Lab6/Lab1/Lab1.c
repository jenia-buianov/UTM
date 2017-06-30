#include <windows.h>
#include <string.h>
#include <time.h>
#include <math.h>

#define ID_TIMER 1
#define TWOPI (2 * 3.14159)

RECT rect;

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR szCmdLine, int iCmdShow)
{
	static char szAppName[] = "ADClock";

	HWND hwnd;

	MSG msg;

	WNDCLASSEX wndclass;

	wndclass.cbSize = sizeof(wndclass);

	wndclass.style = CS_HREDRAW | CS_VREDRAW;

	wndclass.lpfnWndProc = WndProc;

	wndclass.cbClsExtra = 0;

	wndclass.cbWndExtra = 0;

	wndclass.hInstance = hInstance;

	wndclass.hIcon = NULL;

	wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);

	wndclass.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);

	wndclass.lpszMenuName = NULL;

	wndclass.lpszClassName = (LPCWSTR)szAppName;

	wndclass.hIconSm = NULL;

	RegisterClassEx(&wndclass);

	hwnd = CreateWindow((LPCWSTR)szAppName, 
		
		"Analog Clock & Digital Clock",

		WS_OVERLAPPEDWINDOW,

		CW_USEDEFAULT, 
		
		CW_USEDEFAULT,

		CW_USEDEFAULT, 
		
		CW_USEDEFAULT,

		NULL,
		
		NULL,
		
		hInstance, 
		
		NULL);
	//Устанавливаем таймер
	if (!SetTimer(hwnd, ID_TIMER, 1000,NULL))
	{
		MessageBox(hwnd, "Too many clocks or timers!", (LPCWSTR)szAppName, MB_ICONEXCLAMATION | MB_OK);
		return FALSE;
	}

	ShowWindow(hwnd, iCmdShow);

	UpdateWindow(hwnd);

	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return msg.wParam;
}

void SetIsotropic(HDC hdc, int cxClient, int cyClient)
{
	SetMapMode(hdc, MM_ISOTROPIC); //режим отображения указанного контекста устройства
	SetWindowExtEx(hdc, 1000, 1000, NULL); // установление значений окна
	SetViewportExtEx(hdc, cxClient / 2, -cyClient / 2, NULL); //размеры области просмотра
	SetViewportOrgEx(hdc, cxClient / 2, cyClient / 2, NULL); //опредение точки отображения начала координат
}

void RotatePoint(POINT pt[], int iNum, int iAngle)
{
	int i;
	POINT ptTemp;

	for (i = 0; i < iNum; i++)
	{
		ptTemp.x = (int)(pt[i].x * cos(TWOPI * iAngle / 360) + pt[i].y * sin(TWOPI * iAngle / 360));
		ptTemp.y = (int)(pt[i].y * cos(TWOPI * iAngle / 360) - pt[i].x * sin(TWOPI * iAngle / 360));
		pt[i] = ptTemp;
	}
}

void DrawClock(HDC hdc)
{

	int iAngle;
	POINT pt[3];
	HBRUSH penni;
	penni = CreateSolidBrush(RGB(0, 110, 255));

	for (iAngle = 0; iAngle < 360; iAngle += 6)
	{
		pt[0].x = 0;
		pt[0].y = 900;
          RotatePoint(pt, 1, iAngle); // вращение отображения точки
          pt[2].x = pt[2].y = iAngle % 5 ? 33 : 100;
          pt[0].x -= pt[2].x / 2;
          pt[0].y -= pt[2].y / 2;
          pt[1].x = pt[0].x + pt[2].x;
          pt[1].y = pt[0].y + pt[2].y;
          SelectObject(hdc, penni);
          Rectangle(hdc, pt[0].x, pt[0].y, pt[1].x, pt[1].y);
	}
}

void DrawHands(HDC hdc, struct tm *datetime, BOOL bChange)
{
	HPEN hPen2;
	struct tm *Time;
	time_t ltime;
	unsigned char szTime[40];

	static POINT pt[3][5] = { 0, -150, 100, -150, 0, 600, -100, -150, 0, -150,
		0, -200, 50, -200, 0, 800, -50, -200, 0, -200,
		0, -180, 10, -180, 0, 800, -10, -180, 0, -180 };
	int i, iAngle[3], a;
	POINT ptTemp[3][5];
	iAngle[0] = (datetime->tm_hour * 30) % 360 + datetime->tm_min / 2;
	iAngle[1] = datetime->tm_min * 6;
	iAngle[2] = datetime->tm_sec * 6;
	memcpy(ptTemp, pt, sizeof(pt));
	
	for (i = bChange ? 0 : 2; i < 3; i++)
	{
		RotatePoint(ptTemp[i], 5, iAngle[i]);
		Polyline(hdc, ptTemp[i], 5);
	}

	hPen2 = CreatePen(PS_SOLID, 10, RGB(255, 154, 2));
	SelectObject(hdc, hPen2);
	time(&ltime);
	Time = localtime(&ltime);
	SelectObject(hdc, hPen2);
	a = wsprintf((LPWSTR)szTime, "%d:%d:%d  %d.%d.20%d", Time->tm_hour, Time->tm_min, Time->tm_sec, Time->tm_mday, Time->tm_mon + 1, Time->tm_year%100);
	TextOut(hdc,-1000, 1000, (LPWSTR)szTime, a);
	//LPWSTR - Long Pointer Word To String
}


LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC, hCompatibleDC;
	PAINTSTRUCT PaintStruct;
	static int nHDif = 0, nVDif = 0, nHPos = 0, nVPos = 0;

	static int cxClient, cyClient;
	static struct tm dtPrevious;
	BOOL bChange;
	HDC hdc;
	PAINTSTRUCT ps;

	time_t lTime;
	struct tm *datetime;

	time(&lTime); //получает текущее время
	datetime = localtime(&lTime); //возвращает значение времени в текущем временном поясе

	switch (iMsg)
	{

	case WM_CREATE:

		time(&lTime);
		datetime = localtime(&lTime);
		dtPrevious = *datetime; // запомнимаем время начала
		return 0;

	case WM_SIZE:

		cxClient = LOWORD(lParam);
		cyClient = HIWORD(lParam);
		return 0;

	case WM_TIMER:

		time(&lTime);
		datetime = localtime(&lTime);
		bChange = datetime->tm_hour != dtPrevious.tm_hour ||datetime->tm_min != dtPrevious.tm_min; // получаем измененное значение времени

		hdc = GetDC(hwnd);
		SetIsotropic(hdc, cxClient, cyClient);
		SelectObject(hdc, GetStockObject(WHITE_PEN));
		DrawHands(hdc, &dtPrevious, bChange); // убираем текущие стрелки с экрана
		SelectObject(hdc,  GetStockObject(BLACK_PEN));
		DrawHands(hdc, datetime, TRUE); // рисуем стрелки
		ReleaseDC(hwnd, hdc); // освобождает общий контекст устройства

		dtPrevious = *datetime;
		return 0;

	case WM_PAINT:

		hdc = BeginPaint(hwnd, &ps);
		SetIsotropic(hdc, cxClient, cyClient);
		DrawClock(hdc); // рисуем часы
		DrawHands(hdc, &dtPrevious, TRUE); // рисуем стрелки
		EndPaint(hwnd, &ps);
		return 0;

	case WM_DESTROY:

		KillTimer(hwnd, ID_TIMER); // удаляем таймер
		PostQuitMessage(0);
		return 0;
	}

	return DefWindowProc(hwnd, iMsg, wParam, lParam);
}
