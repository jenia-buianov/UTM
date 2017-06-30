#include <windows.h>
#include <math.h>
#define PI 3.14159265

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
HBITMAP hBitmap;

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR szCmdLine, int iCmdShow)
{
	static char szAppName[] = "Laba 4";

	HWND hwnd; // handle to window

	MSG msg;

	WNDCLASSEX wndclass; // structure class window

	wndclass.cbSize = sizeof(wndclass); // size of window

	wndclass.style = CS_HREDRAW | CS_VREDRAW; //text align

	wndclass.lpfnWndProc = WndProc; //Long Pointer to Function

	wndclass.cbClsExtra = 0; // reserve extra size

	wndclass.cbWndExtra = 0; // reserve extra size

	wndclass.hInstance = hInstance; //экземпляр программы определяется в струтуре окна

	wndclass.hIcon = LoadIcon(NULL, IDI_APPLICATION);

	wndclass.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);

	wndclass.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);

	wndclass.lpszMenuName = NULL; //Long pointer to size menu

	wndclass.lpszClassName = szAppName; // Long pointer to size application

	RegisterClassEx(&wndclass); //register class window

	hwnd = CreateWindow(

		szAppName, 

		"Lab4", 

		WS_OVERLAPPEDWINDOW, 

		CW_USEDEFAULT, 

		CW_USEDEFAULT, 

		CW_USEDEFAULT, 

		CW_USEDEFAULT,
		
		NULL, 

		NULL, 

		hInstance, 

		NULL
		); 

	hBitmap = (HBITMAP)LoadImage(hInstance, "img.bmp",IMAGE_BITMAP,0, 0, LR_LOADFROMFILE);
	//Загрузка изображения (hInstance, располож картинки, тип картинки, коорд X, коорд Y, тип загрузки)
	ShowWindow(hwnd, iCmdShow);
	//вывод окна
	UpdateWindow(hwnd);
	//обновление окна
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}
LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hdc; //handle device control
	PAINTSTRUCT ps; // структура для вывода рисунков
	RECT rect; // pen description
	HDC hdcImage; //handle device control for painting bitmap
	HGDIOBJ Bitmap; //type for exucuting pen, brush, bitmap, font ...

	static float angle, d;
	static POINT points[3];
	static int x, y;

	switch (iMsg)
	{
	case WM_CREATE:
		d = sqrt(128 * 128 + 128 * 128) / 2;
		x = 500;
		y = 250;
		angle = 0;
		return 0;

	case WM_PAINT:

		hdc = BeginPaint(hwnd, &ps);
		GetClientRect(hwnd, &rect); //получение размеров рабочей области

		points[0].x = x + d*cos(-0.75*PI + angle);
		points[0].y = y + d*sin(-0.75*PI + angle);
		points[1].x = x + d*cos(-0.25*PI + angle);
		points[1].y = y + d*sin(-0.25*PI + angle);
		points[2].x = x + d*cos(-1.25*PI + angle);
		points[2].y = y + d*sin(-1.25*PI + angle);

		hdcImage = CreateCompatibleDC(hdc); 
		//создает контекст устройства в памяти, совместимый с текущим экраном приложения.

		Bitmap = SelectObject(hdcImage, hBitmap);
		// выбор устройства для вывода изображения
		PlgBlt(hdc, points, hdcImage, 0, 0, 128, 128, NULL, 0, 0);
		// передача данных битов о цвете из заданного прямоугольника, в заданный конекст
		/*
		HDC - целевой
		целевые точки
		HDC - источника
		x координата источника
		y координата источника
		ширина изображения из источника
		высота изображения из источника
		битовая маска
		x коорд битовой маски
		y коорд битовой маски
		*/
		SelectObject(hdcImage, Bitmap);
		// выбор устройства для вывода изображения
		DeleteDC(hdcImage);
		// удаляем заданный контекст устройства
		EndPaint(hwnd, &ps);
		return 0;

	case WM_KEYDOWN:
		switch (wParam) {

		case VK_SHIFT:
			angle = 0;
			y = 250;
			x = 500;
			break;
		case 'L':
			angle -= PI / 20;
			break;

		case 'R':
			angle += PI / 20;
			break;

		case VK_UP:
			y -= 30;
			break;

		case VK_DOWN:
			y += 30;
			break;

		case VK_LEFT:
			x -= 30;
			break;

		case VK_RIGHT:
			x += 30;
			break;
		}

		InvalidateRect(hwnd, NULL, TRUE); //помещает сообщение wm_paint в очередь
		return 0;

	case WM_DESTROY:

		PostQuitMessage(0);
		return 0;
	}
	return DefWindowProc(hwnd, iMsg, wParam, lParam);
}
