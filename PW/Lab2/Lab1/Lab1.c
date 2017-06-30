#include <windows.h> 

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR szCmdLine, int iCmdShow) {

	static char szAppName[] = "HelloWin";

	HWND hwnd;

	MSG msg;

	WNDCLASSEX wndclass;

	wndclass.cbSize = sizeof(wndclass);

	wndclass.style = CS_HREDRAW | CS_VREDRAW;

	wndclass.lpfnWndProc = WndProc;

	wndclass.cbClsExtra = 0; // 

	wndclass.cbWndExtra = 0;

	wndclass.hInstance = hInstance; // description of object

	wndclass.hIcon = LoadIcon(NULL, IDI_APPLICATION);

	wndclass.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);

	wndclass.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);

	wndclass.lpszMenuName = NULL;

	wndclass.lpszClassName = szAppName;

	RegisterClassEx(&wndclass);

	hwnd = CreateWindow(szAppName,

		"Lab 2",

		WS_OVERLAPPEDWINDOW,

		CW_USEDEFAULT,

		CW_USEDEFAULT,

		CW_USEDEFAULT,

		CW_USEDEFAULT,

		NULL,

		NULL,

		hInstance,

		NULL);

	ShowWindow(hwnd, iCmdShow);

	UpdateWindow(hwnd);

	while (GetMessage(&msg, NULL, 0, 0)) {

		TranslateMessage(&msg);

		DispatchMessage(&msg);

	}

	return msg.wParam;

}


LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) {

	HDC hdc; // hadle device control

	PAINTSTRUCT ps; // structure for drowing. (HDC, RECT)

	RECT rect; // size of window

	HBRUSH hBrush; // brush description

	HPEN hPen0,hPen1; // pen description

	POINT pt; // point structure [x][y]

switch (iMsg) {

	case WM_PAINT:
		
		hdc = BeginPaint(hwnd, &ps);
		GetClientRect(hwnd, &rect); //get coordinats of working path. Left Top position, Right Bottom.

		//top
		hBrush = CreateSolidBrush(RGB(0, 142, 16)); // create green brush
		SelectObject(hdc, hBrush); // select created brush in context of window

		RoundRect(hdc, 200, 23, 830, 118, 737, 18);

		SetBkColor(hdc, RGB(0, 142, 16));
		TextOut(hdc, 340, 55, "Lab 2 from TI-155 group Buianov Evghenii", 40);
		

		//sun

		hPen1 = CreatePen(PS_SOLID, 1, RGB(255, 216, 0)); //(TYPE of pen, charset Width, color)
		SelectObject(hdc, hPen1);

		hBrush = CreateSolidBrush(RGB(255, 250, 2));
		SelectObject(hdc, hBrush);
		Ellipse(hdc, 200,150,280,230); // (xLeft, yTop, xRight, yBottom)
		SetBkColor(hdc, RGB(0, 0, 0));

		//car
		hPen0 = CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
		SelectObject(hdc, hPen0);

		MoveToEx(hdc,250,420,&pt); // move pen to fixed position
		LineTo(hdc, 250,370);

		MoveToEx(hdc,250,370,&pt);
		LineTo(hdc, 320,370);

		MoveToEx(hdc,320,370,&pt);
		LineTo(hdc, 400,290);

		MoveToEx(hdc,400,290,&pt);
		LineTo(hdc, 600,290);

		MoveToEx(hdc,600,290,&pt);
		LineTo(hdc, 650,370);

		MoveToEx(hdc,650,370,&pt);
		LineTo(hdc, 750,370);

		MoveToEx(hdc,750,370,&pt);
		LineTo(hdc, 750,420);

		MoveToEx(hdc,750,420,&pt);
		LineTo(hdc, 250,420);
		
		SetBkColor(hdc, RGB(255, 255, 255));
		TextOut(hdc, 480, 335, "CAR", 3);

		//left ellipse
		hBrush = CreateSolidBrush(RGB(0, 0, 0));
		SelectObject(hdc, hBrush);
		Ellipse(hdc, 320,400,370,450);
		SetBkColor(hdc, RGB(0, 0, 0));
		
		//right ellipse
		hBrush = CreateSolidBrush(RGB(0, 0, 0));
		SelectObject(hdc, hBrush);
		Ellipse(hdc, 650,400,700,450);
		SetBkColor(hdc, RGB(0, 0, 0));
		EndPaint(hwnd, &ps);

		break;

	case WM_DESTROY:

		PostQuitMessage(0);

		return 0;
	}

	return DefWindowProc(hwnd, iMsg, wParam, lParam);

} 
