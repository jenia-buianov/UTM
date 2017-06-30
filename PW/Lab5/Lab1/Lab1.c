#include <windows.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR szCmdLine, int iCmdShow) {

	static char szAppName[] = "Laba 5 - Bezier";

	HWND hwnd; // handle to window

	MSG msg;

	WNDCLASSEX wndclass; // structure class window

	wndclass.cbSize = sizeof(wndclass); // size of window

	wndclass.style = CS_HREDRAW | CS_VREDRAW; //text align

	wndclass.lpfnWndProc = WndProc; //Long Pointer to Function

	wndclass.cbClsExtra = 0; // reserve extra size

	wndclass.cbWndExtra = 0; // reserve extra size

	wndclass.hInstance = hInstance; //экземпл€р программы определ€етс€ в струтуре окна

	wndclass.hIcon = LoadIcon(NULL, IDI_APPLICATION);

	wndclass.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);

	wndclass.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);

	wndclass.lpszMenuName = NULL; //Long pointer to size menu

	wndclass.lpszClassName = szAppName; // Long pointer to size application

	RegisterClassEx(&wndclass); //register class window

	hwnd = CreateWindow(

		szAppName, 

		"Lab 5 - Bezier", 

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

	ShowWindow(hwnd, iCmdShow);

	UpdateWindow(hwnd);

	while (GetMessage(&msg, NULL, 0, 0)) {

		TranslateMessage(&msg);

		DispatchMessage(&msg);
	}

	return msg.wParam;
}

void DrawBezier(HDC hdc, POINT pt[])
{
	PolyBezier(hdc, pt, 4);
	MoveToEx(hdc, pt[0].x, pt[0].y, NULL);
	LineTo(hdc, pt[1].x, pt[1].y);
	MoveToEx(hdc, pt[2].x, pt[2].y, NULL);
	LineTo(hdc, pt[3].x, pt[3].y);
}

LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) {
	static POINT pt[4];
	HDC hdc;
	PAINTSTRUCT ps;

	switch (iMsg) {

	case WM_CREATE:

		hdc = GetDC(hwnd);
			
		pt[0].x = 100;
		pt[0].y = 100;
		pt[1].x = 300;
		pt[1].y = 200;
		pt[2].x = 400;
		pt[2].y = 300;
		pt[3].x = 600;
		pt[3].y = 700;

		SelectObject(hdc, GetStockObject(BLACK_PEN));
		DrawBezier(hdc, pt);
		ReleaseDC(hwnd, hdc);

		return 0;

	case WM_MOUSEMOVE:

		if (wParam & MK_LBUTTON || wParam & MK_RBUTTON)
		{
			hdc = GetDC(hwnd);
			SelectObject(hdc, GetStockObject(WHITE_PEN));
			DrawBezier(hdc, pt);

			if (wParam & MK_LBUTTON)
			{
				pt[1].x = LOWORD(lParam);
				pt[1].y = HIWORD(lParam);
			}

			if (wParam & MK_RBUTTON)
			{
				pt[2].x = LOWORD(lParam);
				pt[2].y = HIWORD(lParam);
			}
			SelectObject(hdc, GetStockObject(BLACK_PEN));
			DrawBezier(hdc, pt);
			ReleaseDC(hwnd, hdc);
		}
		return 0;
	case WM_KEYDOWN:
		
		switch (wParam) {
		case 'R':
			
			hdc = GetDC(hwnd);
			SelectObject(hdc, GetStockObject(WHITE_PEN));
			DrawBezier(hdc, pt);

			pt[1].x = 300;
			pt[1].y = 200;
			
			pt[2].x = 400;
			pt[2].y = 300;

			SelectObject(hdc, GetStockObject(BLACK_PEN));
			DrawBezier(hdc, pt);
			ReleaseDC(hwnd, hdc);

			break;
		}
		return 0;
	case WM_DESTROY:

		PostQuitMessage(0);
		return 0;
	}
	return DefWindowProc(hwnd, iMsg, wParam, lParam);
}
