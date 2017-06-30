#include <windows.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR szCmdLine, int iCmdShow) {

	static char szAppName[] = "Lab 3";
	
	HWND hwnd; // handle to window,
	+
	MSG msg; 

	WNDCLASSEX wndclass; // structure class window

	wndclass.cbSize = sizeof(wndclass); // size of window

	wndclass.style = CS_HREDRAW | CS_VREDRAW; //text align

	wndclass.lpfnWndProc = WndProc; //Long Pointer to Function

	wndclass.cbClsExtra = 0; // reserve extra size

	wndclass.cbWndExtra = 0; // reserve extra size

	wndclass.hInstance = hInstance; //экземпл€р программы определ€етс€ в струтуре окна

	wndclass.hIcon = LoadIcon(NULL, IDI_APPLICATION);

	wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);

	wndclass.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	//GetStockObject - выбор кисти
	wndclass.lpszMenuName = NULL; //Long pointer to size menu

	wndclass.lpszClassName = szAppName; // Long pointer to size application

	wndclass.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	RegisterClassEx(&wndclass); //register class window

	hwnd = CreateWindow( szAppName, 

		"Lab 3 - Bezzier", 

		WS_OVERLAPPEDWINDOW, 

		CW_USEDEFAULT, 
	
		CW_USEDEFAULT, 

		CW_USEDEFAULT, 

		CW_USEDEFAULT, 

		NULL, 

		NULL, 

		hInstance, 

		NULL );

	ShowWindow(hwnd, iCmdShow);

	UpdateWindow(hwnd);

	while (GetMessage(&msg, NULL, 0, 0)) {

		TranslateMessage(&msg);

		DispatchMessage(&msg);
	}

	return msg.wParam;
}

LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) {

	static POINT pt[4];

	HDC hdc; //handle device control
	PAINTSTRUCT ps; // структура дл€ вывода рисунков
	
	HPEN hpen1; // pen description
	int x;
	int y;
	double t;
	int startX = 100;
	int startY = 250;
	int startXManual = startX+400;
	int startYManual = startY+200;
	
	switch (iMsg) {

	case WM_PAINT:

		hdc = BeginPaint(hwnd, &ps);

		hpen1 = CreatePen(PS_SOLID, 2, RGB(0, 127, 14));

		SelectObject(hdc, hpen1);

		pt[0].x = startX;
		pt[0].y = startY;
		pt[1].x = pt[0].x+100;
		pt[1].y = pt[0].y-200;
		pt[2].x = pt[1].x+100;
		pt[2].y = pt[1].y+200;
		pt[3].x = pt[2].x+100;
		pt[3].y = pt[2].y-200;

		PolyBezier(hdc, pt, 4);


		hpen1 = CreatePen(PS_SOLID, 2, RGB(48, 96, 255));

		SelectObject(hdc, hpen1);

		MoveToEx(hdc, startXManual, startYManual, NULL);

		pt[0].x = startXManual;
		pt[0].y = startYManual;
		pt[1].x = pt[0].x+100;
		pt[1].y = pt[0].y-200;
		pt[2].x = pt[1].x+100;
		pt[2].y = pt[1].y+200;
		pt[3].x = pt[2].x+100;
		pt[3].y = pt[2].y-200;


		for (t = 0; t <= 1; t += 0.05) {

			x = (1 - t) * (1 - t) *(1 - t) * pt[0].x + 3 * (1 - t)* (1 - t) * t * pt[1].x + 3 * t * t * (1 - t)*pt[2].x + t*t*t*pt[3].x;

			y = (1 - t) * (1 - t) *(1 - t) * pt[0].y + 3 * (1 - t)* (1 - t) * t * pt[1].y + 3 * t * t * (1 - t)*pt[2].y + t*t*t*pt[3].y;

			LineTo(hdc, x, y);
		}

		EndPaint(hwnd, &ps);

		return 0;

	case WM_DESTROY:

		PostQuitMessage(0);

		return 0;
	}
	
	return DefWindowProc(hwnd, iMsg, wParam, lParam); //описатель окна, сообщение, 2 параметра сообщений
}
