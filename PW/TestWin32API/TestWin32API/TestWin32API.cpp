#include "stdafx.h"
#include "TestWin32API.h"
#include <Shobjidl.h>
HINSTANCE hInst;						// ��� ������� ���������
TCHAR szTitle[MAX_LOADSTRING];		   // The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];	// �������� ��������� ������ ���� 
HANDLE OpenFile(HWND hWnd);
HANDLE OpenSaveFile(HWND hWnd);
BOOL bUpdate;									// ����������� �� ���� edit
				//��������� �� ������� ���� ��� �������� ������������

ATOM				MyRegisterClass(HINSTANCE hInstance); //������� � ��������
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

//���������� ������������� ������ ��� ������ � ����� �����
int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	/* UNREFERENCED_PARAMETER ������������ � ������������ �������� ��� ���������. ��� �������������� - �������� �������������� ����������� � ������� ����������, �� ������� ��� ������ (�������������� ����������).*/

	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);
	MSG msg;
	HACCEL hAccelTable;

	// ��������� �����
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_TESTWIN32API, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}
	//������� LoadAccelerators ��������� �������� ������� ������-�����������.
	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_TESTWIN32API));

	// �������� ���� ���������
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}

ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_TESTWIN32API));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_TESTWIN32API);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//� ���� ������� �� ��������� ���������� ���������� � ���������� ���������� �
// ������� � ���������� ������� ���� ���������.

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; //������� ���������� ���������� � ����� ���������� ����������

   // WS_OVERLAPPEDWINDOW -���������� ����� ���� 
   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}


//  WM_COMMAND	- ���������� ���� ����������
//  WM_DESTROY	- post a quit message and return
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;

	static HWND hEdit;
	static HWND hButtonNew;
	static HWND hButtonOpen;
	static HWND hButtonSave;
	static HWND hButtonExit;

	switch (message)
	{

		case WM_CREATE:
		{
			hEdit = CreateWindow((LPCTSTR)L"edit", NULL, WS_CHILD | WS_VISIBLE | WS_BORDER | WS_HSCROLL | WS_VSCROLL | ES_LEFT | ES_AUTOHSCROLL | ES_AUTOVSCROLL | ES_MULTILINE, 0, 0, 0, 0, hWnd, (HMENU)ID_EDIT, hInst, NULL);
			bUpdate = FALSE;
			//����������� ���� ������ ���������� 
			/*
			WS_CHILD -������� ��������� ����.

			
			*/
			hButtonNew = CreateWindow((LPCTSTR)L"button", (LPCTSTR)L"New", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 5, 5, 50, 20, hWnd, (HMENU)ID_NEW, hInst, NULL);
			hButtonOpen = CreateWindow((LPCTSTR)L"button", (LPCTSTR)L"Open", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 65, 5, 50, 20, hWnd, (HMENU)ID_OPEN, hInst, NULL);
			hButtonSave = CreateWindow((LPCTSTR)L"button", (LPCTSTR)L"Save", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 125, 5, 50, 20, hWnd, (HMENU)ID_SAVE, hInst, NULL);
			hButtonExit = CreateWindow((LPCTSTR)L"button", (LPCTSTR)L"Exit", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 185, 5, 50, 20, hWnd, (HMENU)ID_EXIT, hInst, NULL);
			break;
		}

		case WM_SIZE:
		{
			MoveWindow(hEdit, 0, 30, LOWORD(lParam), HIWORD(lParam) - 30, TRUE);
			break;
		}

		//��������� WM_SETFOCUS ������������ ���� ����� ����, ��� ��� �������� ����� ����������.
		/*
		Wparam -���������� ����, ������� �������� ����� ����������. ���� �������� ����� ���� ��������� ����� (NULL)).
		*/
		case WM_SETFOCUS:
		{
			SetFocus(hEdit);
			break;
		}

		case WM_COMMAND:
		{
			wmId    = LOWORD(wParam);
			wmEvent = HIWORD(wParam);

			switch (wmId)
			{
				case ID_EDIT:
				{
					if (wmEvent == EN_ERRSPACE)
						MessageBox(hWnd, (LPCTSTR)L"Too little memory!", (LPCTSTR)L"Notification", MB_OK);
					else if (wmEvent == EN_UPDATE)
						bUpdate = TRUE;

					break;
				}
				
				case ID_NEW:
				{
					if (bUpdate)
					{
						//������� �������� ���� (������) � ������� ��������� � ����������� �� ������
						if (IDYES == MessageBox(hWnd, (LPCWSTR)L"File has been modified. Save changes?", (LPCTSTR)L"Notification", MB_YESNO | MB_ICONQUESTION))
						{
							SendMessage(hButtonSave, BM_CLICK, 0, 0);

							// ��������� ������ - ������� ��� ���������� ����� �� ������� � ����� ��, ���� ��� ���, - ������: ��� ����� ���������� ��� ����� �� ����������� ��������� 
							if (bUpdate	&& IDNO == MessageBox(hWnd, (LPCWSTR)L"Old data was not saved. Create new file otherwise (with lost of data)?", (LPCTSTR)L"Notification", MB_YESNO | MB_ICONQUESTION))
								break;
						}

						bUpdate = FALSE;
					}
					/*
					������� SetWindowText �������� ����� ��������� ��������� ���� (���� ������� �������). ���� ������������ ���� - ����� ����������, �� ���������� ��� �����. 
					������ SetWindowText �� ����� �������� ����� ������ ���������� � ������ ����������.
					*/
					SetWindowText(hEdit, (LPCTSTR)L"\0");
					break;
				}
				case ID_OPEN:
				{
					if (bUpdate)
					{
						if (IDYES == MessageBox(hWnd, (LPCWSTR)L"File has been modified. Save changes?", (LPCTSTR)L"Notification", MB_YESNO | MB_ICONQUESTION))
						{
							SendMessage(hButtonSave, BM_CLICK, 0, 0);

							// ��������� ������ - ������� ��� ���������� ����� �� ������� � ����� ��, ���� ��� ���, - ������: ��� ����� ���������� ��� ����� �� ����������� ��������� 
							if (bUpdate	&& IDNO == MessageBox(hWnd, (LPCWSTR)L"Old data was not saved. Open file otherwise (with lost of old data)?", (LPCTSTR)L"Notification", MB_YESNO | MB_ICONQUESTION))
								break;
						}

						bUpdate = FALSE;
					}

					HANDLE hf = OpenFile(hWnd);
					DWORD dwBytesToRead = 0; // ��� ������ � ������� �������� 
					DWORD dwBytesRead = 0;
					DWORD dwCharsToRead = 0;

					if (hf == INVALID_HANDLE_VALUE)
						break;

					LARGE_INTEGER nFileSize;
					GetFileSizeEx(hf, &nFileSize);
					dwBytesToRead = nFileSize.LowPart;

					if (dwBytesToRead > MAX_FILESIZE)
					{
						CloseHandle(hf);
						MessageBox(hWnd, (LPCTSTR)L"The file size more than MAX_FILESIZE.", (LPCTSTR)L"Notification", MB_OK);
						break;
					}
					//�������� ��� �������� 
					LPSTR lpMultiByteStr = new CHAR[dwBytesToRead + 1];

					if (!ReadFile(hf, lpMultiByteStr, dwBytesToRead, &dwBytesRead, NULL) || dwBytesRead == 0) 
					{
						CloseHandle(hf);
						delete []lpMultiByteStr;
						MessageBox(hWnd, (LPCTSTR)L"An error occurred while reading the file!", (LPCTSTR)L"Error", MB_OK | MB_ICONWARNING);
						break;
					}

					CloseHandle(hf);

					if (dwBytesRead > 0 && dwBytesRead <= dwBytesToRead)
					{
						lpMultiByteStr[dwBytesRead] = '\0';
					}
					else if (dwBytesRead == 0)
					{
						MessageBox(hWnd, (LPCTSTR)L"No data read from file!", (LPCTSTR)L"Error", MB_OK | MB_ICONWARNING);
					}
					else
					{
						MessageBox(hWnd, (LPCTSTR)L"An error occurred while reading the file!", (LPCTSTR)L"Error", MB_OK | MB_ICONWARNING);
					}

					dwCharsToRead = MultiByteToWideChar(CP_UTF8, 0, lpMultiByteStr, -1, NULL , 0);

					LPTSTR lpTextBuffer = new TCHAR[dwCharsToRead];

					MultiByteToWideChar(CP_UTF8, 0, lpMultiByteStr, -1, lpTextBuffer, dwCharsToRead);
					SetWindowText(hEdit, (LPCTSTR)lpTextBuffer);
					delete []lpMultiByteStr;
					delete []lpTextBuffer;
					bUpdate = FALSE;
					break;
				}
				// �������� ����� (txt.)
				case ID_SAVE:
				{
					DWORD dwCharsToWrite;
					DWORD dwBytesToWrite;
					DWORD dwBytesWritten;
					HANDLE hTxtBuf;
					PTCHAR npTextBuffer;
					HANDLE hf = OpenSaveFile(hWnd);

					if (hf == INVALID_HANDLE_VALUE)
						break;

					dwCharsToWrite = GetWindowTextLength(hEdit);

					hTxtBuf = (HANDLE)SendMessage(hEdit, EM_GETHANDLE, 0, 0);
					npTextBuffer = (PTCHAR)LocalLock(hTxtBuf);
					//����� ��� ������ 
					dwBytesToWrite = WideCharToMultiByte(CP_UTF8, 0, npTextBuffer, dwCharsToWrite, NULL, 0, NULL, NULL );
					LPSTR lpMultiByteStr = new CHAR[dwBytesToWrite];	
					WideCharToMultiByte(CP_UTF8, 0, npTextBuffer, dwCharsToWrite, lpMultiByteStr, dwBytesToWrite, NULL, NULL );

					if (!WriteFile(hf, lpMultiByteStr, dwBytesToWrite, &dwBytesWritten, NULL) || dwBytesWritten != dwBytesToWrite)
						MessageBox(hWnd, (LPCTSTR)L"An error has been occurred while saving the file!", (LPCTSTR)L"Error", MB_OK | MB_ICONWARNING);
					else
						bUpdate = FALSE;

					CloseHandle(hf);
					delete []lpMultiByteStr;
					LocalUnlock(hTxtBuf);
					break;
				}
				//��������� ������
				case ID_EXIT:
				{
					if (bUpdate)
					{
						//IDYES -��������� ��� ������� ���� ��� ������ �������� 
						if (IDYES == MessageBox(hWnd, (LPCWSTR)L"File has been modified. Save changes?", (LPCTSTR)L"Notification", MB_YESNO | MB_ICONQUESTION))
						{
							SendMessage(hButtonSave, BM_CLICK, 0, 0);// ���� ������ ������� ...

							// ��������� ������ - ������� ��� ���������� ����� �� ������� � ����� ��, ���� ��� ���, - ������: ��� ����� ���������� ��� ����� �� ����������� ��������� 
							if (bUpdate	&& IDNO == MessageBox(hWnd, (LPCWSTR)L"The data was not saved. Exit otherwise (with lost of data)?", (LPCTSTR)L"Notification", MB_YESNO | MB_ICONQUESTION))
								break;
						}

						bUpdate = FALSE;
					}

					SendMessage(hWnd, WM_CLOSE, 0, 0);
					break;
				}
			}

			// ������� ����
			switch (wmId)
			{
				

				case IDM_ABOUT:
				{
					DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
					break;
				}

				case IDM_EXIT:
				{
					DestroyWindow(hWnd);
					break;
				}

				default:
					return DefWindowProc(hWnd, message, wParam, lParam);
			}

			break;
		}

		case WM_PAINT:
		{
			hdc = BeginPaint(hWnd, &ps);
			//TextOut(hdc, 10, 20, (LPCWSTR)L"WM_PAINT message has been received.", 35);
			EndPaint(hWnd, &ps);
			break;
		}

		case WM_DESTROY:
		{
			PostQuitMessage(0);
			break;
		}

		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// ���������� ��� ��������� ��������� 
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}

// ������ �������� �����
HANDLE OpenFile(HWND hWnd)
{
    IFileOpenDialog *pFileOpenDialog;
    
    HRESULT hr = CoCreateInstance(CLSID_FileOpenDialog, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&pFileOpenDialog));
	HANDLE hf;

	if (SUCCEEDED(hr))
	{
		COMDLG_FILTERSPEC rgSpec[] =
		{ 
			//��������� ����� ������� � ���������� �������������� 
			{ L"Images (*.jpg)", L"*.jpg" },
			{ L"Text Files (*.txt)", L"*.txt" },
			{ L"All Files (*.*)", L"*.*" }
		};

		hr = pFileOpenDialog -> SetFileTypes(2, rgSpec);

		if (SUCCEEDED(hr))
		{
			hr = pFileOpenDialog -> Show(hWnd);

			if (SUCCEEDED(hr))
			{
				IShellItem *psiCurrent = 0;
				hr = pFileOpenDialog -> GetResult(&psiCurrent);

				if (SUCCEEDED(hr))
				{
					LPTSTR pszPath = 0;
					hr = psiCurrent -> GetDisplayName(SIGDN_FILESYSPATH, &pszPath);

					if (SUCCEEDED(hr))
					{
						hf = CreateFile(pszPath, GENERIC_READ, 0, NULL, OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
						CoTaskMemFree(pszPath);
						return hf;
					}

					psiCurrent -> Release();
				}
			}
		}
	}

	return 0;
}

// ������ ���������� �����
HANDLE OpenSaveFile(HWND hWnd)
{
    IFileSaveDialog *pFileSaveDialog;
    
    HRESULT hr = CoCreateInstance(CLSID_FileSaveDialog, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&pFileSaveDialog));
	HANDLE hf;

	if (SUCCEEDED(hr))
	{
		COMDLG_FILTERSPEC rgSpec[] =
		{ 
			{ L"Text Files (*.txt)", L"*.txt" },
			{ L"All Files (*.*)", L"*.*" }
		};

		hr = pFileSaveDialog -> SetFileTypes(2, rgSpec);

		if (SUCCEEDED(hr))
		{
			hr = pFileSaveDialog -> Show(NULL);

			if (SUCCEEDED(hr))
			{
				IShellItem *psiCurrent = 0;
				hr = pFileSaveDialog -> GetResult(&psiCurrent);

				if (SUCCEEDED(hr))
				{
					LPTSTR pszPath = 0;
					hr = psiCurrent -> GetDisplayName(SIGDN_FILESYSPATH, &pszPath);

					if (SUCCEEDED(hr))
					{
						hf = CreateFile(pszPath, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
						CoTaskMemFree(pszPath);
						return hf;
					}
					
					psiCurrent -> Release();
				}
			}
		}
	}

	return 0;
}