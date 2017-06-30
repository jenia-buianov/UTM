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

	wndclass.hInstance = hInstance; //��������� ��������� ������������ � �������� ����

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
	//�������� ����������� (hInstance, �������� ��������, ��� ��������, ����� X, ����� Y, ��� ��������)
	ShowWindow(hwnd, iCmdShow);
	//����� ����
	UpdateWindow(hwnd);
	//���������� ����
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
	PAINTSTRUCT ps; // ��������� ��� ������ ��������
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
		GetClientRect(hwnd, &rect); //��������� �������� ������� �������

		points[0].x = x + d*cos(-0.75*PI + angle);
		points[0].y = y + d*sin(-0.75*PI + angle);
		points[1].x = x + d*cos(-0.25*PI + angle);
		points[1].y = y + d*sin(-0.25*PI + angle);
		points[2].x = x + d*cos(-1.25*PI + angle);
		points[2].y = y + d*sin(-1.25*PI + angle);

		hdcImage = CreateCompatibleDC(hdc); 
		//������� �������� ���������� � ������, ����������� � ������� ������� ����������.

		Bitmap = SelectObject(hdcImage, hBitmap);
		// ����� ���������� ��� ������ �����������
		PlgBlt(hdc, points, hdcImage, 0, 0, 128, 128, NULL, 0, 0);
		// �������� ������ ����� � ����� �� ��������� ��������������, � �������� �������
		/*
		HDC - �������
		������� �����
		HDC - ���������
		x ���������� ���������
		y ���������� ���������
		������ ����������� �� ���������
		������ ����������� �� ���������
		������� �����
		x ����� ������� �����
		y ����� ������� �����
		*/
		SelectObject(hdcImage, Bitmap);
		// ����� ���������� ��� ������ �����������
		DeleteDC(hdcImage);
		// ������� �������� �������� ����������
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

		InvalidateRect(hwnd, NULL, TRUE); //�������� ��������� wm_paint � �������
		return 0;

	case WM_DESTROY:

		PostQuitMessage(0);
		return 0;
	}
	return DefWindowProc(hwnd, iMsg, wParam, lParam);
}
