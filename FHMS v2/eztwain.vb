'  EZTwain for VB.NET
'  XDefs translation of \EZTwain\VC\Eztwain.h
'  EZTwain 3.30.0.28, XDefs 1.36b1
Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices

Friend Class EZTwain

    Public Shared Function DibToImage(ByVal hdib As System.IntPtr) As Image
        Dim data(EZTwain.DIB_Size(hdib) + 100) As Byte
        EZTwain.DIB_WriteToBuffer(hdib, EZTwain.TWFF_BMP, data(0), data.Length)
        Dim s As New System.IO.MemoryStream(data, False)
        Dim im As Image = Image.FromStream(s)
        DibToImage = CType(im.Clone, Image)
        im.Dispose()
        s.Dispose()
    End Function

    Public Shared Function DIB_ToImage(ByVal hdib As System.IntPtr) As Image
        DIB_ToImage = DibToImage(hdib)
    End Function

    ' EZTWAIN.H - Easy interface to TWAIN library
    ' Copyright (C) 1999-2009 by Dosadi.
    '
    ' This interface and the library which implements it, are the property of
    ' Dosadi and are protected by US and International copyright and trademark
    ' laws and treaties.  Dosadi strives to make this software both reliable,
    ' comprehensive, efficient, and affordable.  Do not use this software without
    ' obtaining a license for your use.
    ' 
    ' Sales, support and licensing information at: www.dosadi.com
    '



    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Testing123")> _
    Public Shared Function Testing123(ByVal s As String, ByVal n As Int32, ByVal h As IntPtr, ByVal d As Double, ByVal u As Int32) As IntPtr
    End Function
    ' Displays a dialog box showing the parameter values received by the function.
    ' Pass in any valid values for the parameters - if they are faithfully
    ' displayed in the dialog box when you call this function, then parameter
    ' passing from your program to EZTwain is probably working correctly.
    '
    ' Returns the value of the HDIB h parameter.

    '--------- Top-Level Calls

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Acquire")> _
    Public Shared Function Acquire(ByVal hwndApp As IntPtr) As IntPtr
    End Function
    ' Acquires a single image, from the currently selected Data Source, using
    ' EZTWAIN's preferred transfer mode.  (Currently the preferred mode is NATIVE)
    '
    ' The parameter is a Win32 Window Handle.  In most applications you
    ' can use 0 or NULL, but on Citrix and WTS, this must be a top-level window
    ' or a child of a top level window.
    '
    ' The return value is a handle to global memory containing a DIB - 
    ' a Device-Independent Bitmap.  Numerous EZTWAIN DIB_xxx functions can
    ' be used to examine, modify, and save these DIB images.
    ' Warning: Remember to call DIB_Free on each DIB when you are done with it!
    '
    ' Normally only one image is acquired per call: All Acquire functions shut
    ' down TWAIN before returning.  Use TWAIN_SetMultiTransfer to change this.
    '
    ' By default, the default data source (DS) is opened, displays its dialog,
    ' and determines all the parameters of the acquisition and transfer.
    ' If you want to (try to) hide the DS dialog, see TWAIN_SetHideUI.
    ' To set acquisition parameters, you need to do something like this:
    '     TWAIN_OpenDefaultSource() -or- TWAIN_OpenSource(sourceName)
    '     TWAIN_Set*        - one or more capability-setting functions
    '     hdib = TWAIN_Acquire(hwnd)
    '     if (hdib) then ... process image, TWAIN_FreeNative(hdib); end

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SelectImageSource")> _
    Public Shared Function SelectImageSource(ByVal hwnd As IntPtr) As Boolean
    End Function
    ' This is the routine to call when the user chooses the "Select Source..."
    ' menu command from your application's File menu.
    ' In the standard implementation of "Select Source...", your application
    ' doesn't need to do anything except make this one call.
    ' Note: If only one TWAIN device is installed on a system, it is selected
    ' automatically, so there is no need for the user to do Select Source.
    ' You should not require your users to do Select Source before Acquire.
    '
    ' This function posts the Source Manager's Select Source dialog box.
    ' It returns after the user either OK's or CANCEL's that dialog.
    ' A return of TRUE(1) indicates OK, FALSE(0) indicates one of the following:
    '   a) The user cancelled the dialog
    '   b) The Source Manager found no data sources installed
    '   c) There was a failure before the Select Source dialog could be posted
    '
    ' If you want to be meticulous, disable your "Acquire" and "Select Source"
    ' menu items or buttons if TWAIN_IsAvailable() returns false - see below.
    '
    ' To enumerate the available data sources, see:
    '     TWAIN_GetSourceList and TWAIN_NextSourceName

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireNative")> _
    Public Shared Function AcquireNative(ByVal hwndApp As IntPtr, ByVal wPixTypes As Int32) As IntPtr
    End Function
    ' Acquires a single image, from the currently selected Data Source, using
    ' Native Transfer Mode. It waits until the source closes (if it's modal) or
    ' forces the source closed if not.  The return value is a handle to the
    ' acquired image.  Only one image can be acquired per call.
    '
    ' The return value is a handle to global memory containing a DIB - 
    ' a Device-Independent Bitmap.  Numerous EZTWAIN functions can
    ' be used to examine, modify, and save these DIBs.  Remember to
    ' use TWAIN_FreeNative to free each DIB when you are done with it,
    ' these things eat up a lot of memory.
    '
    ' For the 2nd parameter, you can OR or add together the following
    ' masks to indicate what kind(s) of image you prefer to receive.
    ' Caution: Some TWAIN devices will ignore your preference here.
    ' -- If you care, check the parameters of the DIB.

    Friend Const TWAIN_BW As Int32 = 1
    Friend Const TWAIN_GRAY As Int32 = 2
    Friend Const TWAIN_RGB As Int32 = 4
    Friend Const TWAIN_PALETTE As Int32 = 8
    Friend Const TWAIN_CMY As Int32 = 16
    Friend Const TWAIN_CMYK As Int32 = 32

    Friend Const TWAIN_ANYTYPE As Int32 = 0

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireToClipboard")> _
    Public Shared Function AcquireToClipboard(ByVal hwndApp As IntPtr, ByVal wPixTypes As Int32) As Boolean
    End Function
    ' Like AcquireNative, but puts the resulting image, if any, into the
    ' system clipboard as a CF_DIB item. If this call fails, the clipboard is
    ' either empty or retains its previous content.
    ' Returns TRUE(1) for success, FALSE(0) for failure.
    '
    ' Useful for environments like Visual Basic where it is hard to make direct
    ' use of a DIB handle.  In fact, TWAIN_AcquireToClipboard uses
    ' TWAIN_AcquireNative for all the hard work.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireMemory")> _
    Public Shared Function AcquireMemory(ByVal hwnd As IntPtr) As IntPtr
    End Function
    ' Like TWAIN_Acquire, but always specifies a 'memory mode' transfer.

    ' Functions to do a memory transfer in individual blocks:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_BeginAcquireMemory")> _
    Public Shared Function BeginAcquireMemory(ByVal hwnd As IntPtr, ByVal nRows As Int32) As Boolean
    End Function
    ' Begin a memory transfer.
    ' Returns TRUE(1) if the transfer is ready to proceed (using
    ' TWAIN_AcquireMemoryBlock, below.)
    ' Returns FALSE(0) if the transfer could not be started for some reason.
    '
    ' Loads TWAIN if necessary, opens the default source if no source is open.
    ' If it opens a source, it negotiates any 'pending' settings (resolution,
    ' pixel type, etc.) that were specified before the device was open.
    ' Enables the device if not already enabled.
    ' Waits for a 'transfer ready' message from the device.
    ' Tells the driver to begin transferring in blocks of nRows rows or less.
    ' If nRows is <= 0, lets the driver pick the optimal block size.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireMemoryBlock")> _
    Public Shared Function AcquireMemoryBlock() As IntPtr
    End Function
    ' Acquire the next block of data in a memory transfer.
    ' If there is an error or there is no more data, returns NULL(0).
    ' Only valid after a successful call to TWAIN_BeginAcquireMemory (above.)
    ' Asks the device to deliver another block of pixels, and returns
    ' those pixels as a DIB represented by its handle.  This is the same
    ' image format returned by TWAIN_AcquireNative, TWAIN_AcquireMemory, etc.
    ' See the DIB_* functions for what can be done with the returned handle.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EndAcquireMemory")> _
    Public Shared Function EndAcquireMemory() As Boolean
    End Function
    ' Clean up after a block-by-block memory transfer.
    ' Only valid after a successful call to TWAIN_BeginAcquireMemory (above.)
    ' Frees any temporary storage, and tells the device the transfer
    ' is over.  In Multi-transfer mode, the device will move to
    ' State 6 if more images are available, or State 5 if not.
    ' In single-transfer mode (the default) the device is automatically closed.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireToFilename")> _
    Public Shared Function AcquireToFilename(ByVal hwndApp As IntPtr, ByVal sFileName As String) As Int32
    End Function
    ' Acquire an image and save it to a file.
    ' If the filename is NULL or an empty string, the user is prompted for
    ' the file name using a standard Save File dialog.
    '
    ' The minimal use of EZTwain is to call this function with both arguments NULL (0).
    '
    ' If the filename passed as a parameter or entered by the user contains a
    ' standard extension (.bmp, .jpg/.jpeg, .tif/.tiff, .png, .pdf, .gif, .dcx)
    ' then the file is saved in the implied format.
    ' Otherwise the file is saved in the current SaveFormat - see TWAIN_SetSaveFormat.

    ' See also TWAIN_AcquireFile below.
    '
    ' Return values:
    '   0  success.
    '  -1  the Acquire failed.
    '  -2  file open error (invalid path or name, or access denied)
    '  -3  invalid DIB, or image incompatible with file format, or...
    '  -4  writing failed, possibly output device is full.
    ' -10  user cancelled File Save dialog


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireMultipageFile")> _
    Public Shared Function AcquireMultipageFile(ByVal hwndApp As IntPtr, ByVal sFileName As String) As Int32
    End Function
    ' Acquire (scan) all available images to a multipage file.
    ' If the filename is NULL or points to the null string, the user is
    ' prompted for the filename.
    ' If the filename ends with ".tif", ".tiff", or
    ' ".mpt" the file is written in TIFF format.
    ' If the filename ends with ".pdf" the file is written in PDF format.
    ' Otherwise, the default multipage format is used, as set by SetMultipageFormat.
    ' If it has not been set, the default multipage format is TIFF.
    '
    ' If scanning fails or is cancelled before the first writable page
    ' is received, no file action is taken: The output filename is not prompted for,
    ' the file is not created, if it exists it is not touched.
    '
    ' The function TWAIN_MultipageCount can be called during or after
    ' writing a multipage file, it reports the number of images written to the file.
    ' See also TWAIN_AcquireCount and TWAIN_BlankDiscardCount for other info.
    '
    ' Return values:
    '   0  success
    '  -1  the Acquire failed, or the device closed or quit after 0 pages.
    '      If 0 pages were written but no other error was diagnosed,
    '      TWAIN_LastErrorCode will be EZTEC_0_PAGES.
    '  -2  file open error (invalid path or name, or access denied)
    '  -3  could not load file-format module (EZTiff.dll or EZPdf.dll)
    '      Either the DLL was not found, or the version is out-of-date,
    '      For PDF output, EZJpeg.dll is also required.
    '      Less likely: The device returned an invalid DIB handle, or
    '      the transferred image has a bit depth of 9..15 bits per pixel (??)
    '  -4  writing failed, possibly output device is full.
    '  -7  Multipage support is not installed.
    ' -10  user cancelled - This can be during the filename prompt, if you
    '      did not supply a filename, or it can be when the scanner dialog
    '      is first displayed.  If the scanner dialog is visible, the user
    '      can cancel during a scan and the dialog will just stay open (usually)
    '      allowing another try.  If the user closed the scan dialog without
    '      scanning, TWAIN_LastErrorCode will be EZTEC_USER_CANCEL.
    '
    ' This function respects TWAIN_SetHideUI as follows:
    ' If SetHideUI(1), then the device UI is hidden, AcquireMultipageFile
    ' will transfer images until the device indicates that it has no
    ' more images ready.  (Technically, it goes to State 5).
    ' Exception: If a device seems to be one-image-at-a-time (such as a flatbed)
    ' the user will be asked if they want to acquire another image.
    '
    ' If SetHideUI(0) [the default case] then the device UI is shown,
    ' and AcquireMultipageFile will transfer images until the user
    ' closes the device dialog.
    '
    ' This function respects SetMultiTransfer() as follows:
    ' If SetMultiTransfer(1), the DS is left open on return.
    ' Otherwise (the default case), the DS is closed and TWAIN is unloaded.
    '
    ' If you want to set scanning parameters (resolution, pixeltype...)
    ' first open the source (see OpenDefaultSource or OpenSource)
    ' then negotiate the settings using the Capability functions, and
    ' then call AcquireMultipageFile.
    '
    ' Caution: It is not recommended to use this function on webcams
    ' if the UI is hidden.  Some will crash, others may supply images
    ' endlessly (until disk full.)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireImagesToFiles")> _
    Public Shared Function AcquireImagesToFiles(ByVal hwndApp As IntPtr, ByVal sFileName As String) As Int32
    End Function
    ' Similar to TWAIN_AcquireMultipageFile above, but writes each
    ' image to a separate file.  The format of the output files is
    ' determined by the extension of the filename, as with AcquireToFilename.
    '
    ' If the filename is NULL or points to the null string, the user is
    ' prompted for the name of the first file.
    '
    ' Files after the first are given names 'incremented' from the name
    ' of the first file according to this pattern:
    ' document.pdf increments to document1.pdf
    ' document99.pdf increments to document100.pdf
    ' document0001.tif increments to document0002.tif.
    '
    ' Return values:
    ' IMPORTANT: If successful, returns the number of files written.
    ' Note that this could be 0 if the scanner dialog is displayed and
    ' the user closes the dialog without any scans.
    ' Otherwise, return value same as TWAIN_AcquireMultipageFile, and
    ' details available from TWAIN_LastErrorCode & related functions.
    ' 
    ' See also: TWAIN_AcquiredFileCount
    '           TWAIN_AcquireCount
    '           TWAIN_BlankDiscardCount.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquirePagesToFiles")> _
    Public Shared Function AcquirePagesToFiles(ByVal hwnd As IntPtr, ByVal nPPF As Int32, ByVal sFile As String) As Int32
    End Function
    ' Similar to AcquireImagesToFiles, but can acquire duplex or multipage files.
    '
    ' hwnd     = parent window. Use 0 (NULL) if you can't obtain the window handle.
    '
    ' nPPF     = *pages* per file.
    '            If the scanner is scanning duplex, 1 page = 2 images
    '            otherwise 1 page = 1 image.
    '
    ' pzFile   = filename.  We recommend including the extension to specify the format.
    '            If the filename is NULL or points to the empty string, the user is
    '            prompted for the name of the first file.
    '
    ' Return: If successful, returns the number of files written.
    ' Otherwise, same as TWAIN_AcquireMultipageFile, with
    ' details available from TWAIN_LastErrorCode & related functions.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquiredFileCount")> _
    Public Shared Function AcquiredFileCount() As Int32
    End Function
    ' Returns the number of files successfully written by the last call to
    ' TWAIN_AcquireImagesToFiles or TWAIN_AcquirePagesToFiles.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireCompressed")> _
    Public Shared Function AcquireCompressed(ByVal hwndApp As IntPtr) As IntPtr
    End Function
    ' Acquire the next available image from the open (or default) device,
    ' accepting a compressed memory transfer if one is selected.
    ' (Use TWAIN_SetCompression to select the compression algorithm.)
    ' 
    ' The DIB handle which is returned will normally reference a compressed
    ' DIB, which is acceptable to very few other EZTwain functions.
    ' See also: DIB_IsCompressed
    '
    ' Recommended use of this function:
    ' Open a device with TWAIN_OpenSource or TWAIN_OpenDefaultSource.
    ' Set any other scanning parameters such as PixelType, resolution, etc.
    ' Select memory transfer mode, using TWAIN_SetXferMech.
    ' Select a compression algorithm, using TWAIN_SetCompression.
    ' Call this function (possibly in a loop) to acquire images.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireCount")> _
    Public Shared Function AcquireCount() As Int32
    End Function
    ' Returns the number of images acquired by the last call to
    ' TWAIN_AcquireMultipageFile, TWAIN_AcquireImagesToFiles,
    ' or TWAIN_AcquirePagesToFiles.
    '
    ' This includes only "keeper" pages - it *excludes*
    ' any discarded blank pages, separator pages, etc.
    '
    ' Therefore it may differ from the value of TWAIN_MultipageCount.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetDefaultScanAnotherPagePrompt")> _
    Public Shared Function SetDefaultScanAnotherPagePrompt(ByVal fYes As Int32) As Int32
    End Function
    ' Controls an aspect of TWAIN_AcquireMultipageFile - When used
    ' with a non-feeder device, with UI suppressed, that function
    ' asks the user if they want to scan another page, [Yes] or [No].
    ' This function controls which answer is the default:
    ' fYes = 1         [Yes] is the default button/answer*
    ' fYes = 0         [No] is the default button/answer.
    '
    ' * EZTwain initial setting.
    '  
    ' Return value: Previous value of the setting.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AcquireFile")> _
    Public Shared Function AcquireFile(ByVal hwndApp As IntPtr, ByVal nFF As Int32, ByVal sFileName As String) As Boolean
    End Function
    ' Acquire an image directly to a file, using the given format and filename.
    ' * Unlike AcquireToFilename, this function uses TWAIN File Transfer Mode.
    ' * The image is written to disk by the Data Source, not by EZTWAIN.
    ' * Warning: This mode is -not- supported by all TWAIN devices.
    ' 
    ' Use TWAIN_SupportsFileXfer to see if the open DS supports File Transfer.
    '
    ' You can use TWAIN_Get(ICAP_IMAGEFILEFORMAT) to get an enumeration of
    ' the available file formats, and CONTAINER_ContainsValue to check for
    ' a particular format you are interested in.
    '
    ' nFF can be any file format supported by the DS, see the TWFF_* constants
    ' in twain.h for the list of allowed formats.  A compliant DS should
    ' at least support TWFF_BMP, but as usual there are no guarantees.
    '
    ' If the filename is NULL or an empty string, the user is prompted for
    ' the file name in a standard Save File dialog.
    '
    ' Return values (N.B. A Boolean, not an error code like AcquireToFilename!)
    '  TRUE(1) for success
    '  FALSE(0) for failure - use GetResultCode/GetConditionCode for details.
    '  If the user cancels the Save File dialog, the result code is TWRC_CANCEL

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DoSettingsDialog")> _
    Public Shared Function DoSettingsDialog(ByVal hwnd As IntPtr) As Int32
    End Function
    ' Run the device's settings dialog, if this is supported, and return
    ' when the user closes the dialog.  See return codes below.
    '
    ' If a device is open, work with that device.  If no device is currently
    ' open, work with the default device.  (See GetDefaultSourceName)
    ' This is an *optional* TWAIN feature - To check if a device supports this,
    ' open the device and call TWAIN_GetCapBool(CAP_ENABLEDSUIONLY, FALSE) -
    ' if that call returns TRUE(1) then this feature is supported.
    ' Return values:
    '    1     dialog was displayed and user clicked OK
    '    0     dialog was displayed and user clicked Cancel
    '   -1     dialog not displayed - some error.  Call LastErrorCode,
    '          ReportLastError, or similar function for more details.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EnableSourceUiOnly")> _
    Public Shared Function EnableSourceUiOnly(ByVal hwnd As IntPtr) As Boolean
    End Function
    ' The underlying 'asynchronous' function for TWAIN_DoSettingsDialog.
    ' Opens the device's settings dialog, if this is supported.
    ' Returns TRUE (1) if successful, FALSE (0) otherwise.
    ' NOTE: If successful, this call leaves the dialog open, so your
    ' program must run a message pump at least until the user closes it.
    ' If you don't understand what that means, don't call this guy.

    '--------- Global Options

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetMultiTransfer")> _
    Public Shared Sub SetMultiTransfer(ByVal bYes As Boolean)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetMultiTransfer")> _
    Public Shared Function GetMultiTransfer() As Boolean
    End Function
    ' This function controls the 'multiple transfers' flag.
    ' By default, this feature is set to FALSE (0).
    '
    ' If this flag is zero, the input device is closed when
    ' any TWAIN_AcquireXXX function finishes.
    '
    ' If this flag is non-zero: After an Acquire, the input device
    ' is not closed, but is left open to allow additional images
    ' to be acquired.  In this case the programmer should
    ' close the input device after all images have been
    ' transferred, by calling either
    '     TWAIN_CloseSource or
    '     TWAIN_UnloadSourceManager
    '
    ' See also: TWAIN_UserClosedSource()

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_WaitForImage")> _
    Public Shared Function WaitForImage(ByVal hwnd As IntPtr) As Boolean
    End Function
    ' ** Experimental - Use with caution **
    '
    ' Returns TRUE(1) if TWAIN device is ready to deliver an image.
    '   -- TWAIN_State() will be 6 in this case.
    ' Returns FALSE(1) if the application should stop acquiring and close the DS.
    '
    ' If no device is open, the default device is opened.
    ' If the device is interacting with the user, waits for the user
    ' to either start a transfer, or close the device dialog.
    ' This function is primarily useful for multiple transfers, in loops like:
    '     IF TWAIN_OpenDefaultSource() AND NegotiateSettings() THEN
    '         WHILE TWAIN_WaitForImage(hwnd)
    '             TWAIN_AcquireToFilename(hwnd, filename)
    '             increment(filename)
    '         END WHILE
    '         TWAIN_CloseSource()
    '     END IF

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetHideUI")> _
    Public Shared Sub SetHideUI(ByVal bHide As Boolean)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetHideUI")> _
    Public Shared Function GetHideUI() As Boolean
    End Function
    ' These functions control the 'hide source user interface' flag.
    ' This flag is cleared initially, but if you set it non-zero, then when
    ' a device is enabled it will be asked to hide its user interface.
    ' Note that this is only a request - some devices will ignore it!
    ' This affects AcquireNative, AcquireToClipboard, and EnableSource.
    ' If the user interface is hidden, you will probably want to set at least
    ' some of the basic acquisition parameters yourself - see
    ' SetUnits, SetPixelType, SetBitDepth and SetResolution below.
    ' See also: HasControllableUI

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DisableParent")> _
    Public Shared Sub DisableParent(ByVal bYes As Boolean)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetDisableParent")> _
    Public Shared Function GetDisableParent() As Boolean
    End Function
    ' Set or get the "DisableParent" flag.
    ' When this flag is set (non-zero), EZTwain attempts to
    ' disable the parent window during any Acquire function.
    ' (The parent window is the window you pass to the Acquire function.
    ' Typically this is your main application window or dialog.)
    ' This flag is TRUE (1) by default.
    '
    ' Note 1: If you set this to FALSE, your window can receive user input while
    ' an Acquire is in progress, and your code must be prepared for this.
    ' Note 2: Some TWAIN data sources will disable the parent window on their
    ' own, and EZTWAIN cannot prevent this.


    '--------- Basic TWAIN Inquiries

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EasyVersion")> _
    Public Shared Function EasyVersion() As Int32
    End Function
    ' Returns the version number of EZTWAIN.DLL, multiplied by 100.
    ' So e.g. version 2.01 will return 201 from this call.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EasyBuild")> _
    Public Shared Function EasyBuild() As Int32
    End Function
    ' Returns the build number within the version.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsAvailable")> _
    Public Shared Function IsAvailable() As Boolean
    End Function
    ' Call this function any time to find out if TWAIN is installed on the
    ' system.  It takes a little time on the first call, after that it's fast,
    ' just testing a flag.  It returns 1 if the TWAIN Source Manager is
    ' installed & can be loaded, 0 otherwise. 

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsMultipageAvailable")> _
    Public Shared Function IsMultipageAvailable() As Boolean
    End Function
    ' Return TRUE (1) if EZTwain 'multipage' services are installed.
    ' This allows writing of multipage TIFF (if TIFF is available)
    ' and multipage PDF (if PDF is available).
    ' It also enables TWAIN_AcquireMultipageFile

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_State")> _
    Public Shared Function State() As Int32
    End Function
    ' Returns the TWAIN Protocol State per the spec.
    Friend Const TWAIN_PRESESSION As Int32 = 1
    Friend Const TWAIN_SM_LOADED As Int32 = 2
    Friend Const TWAIN_SM_OPEN As Int32 = 3
    Friend Const TWAIN_SOURCE_OPEN As Int32 = 4
    Friend Const TWAIN_SOURCE_ENABLED As Int32 = 5
    Friend Const TWAIN_TRANSFER_READY As Int32 = 6
    Friend Const TWAIN_TRANSFERRING As Int32 = 7

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsDone")> _
    Public Shared Function IsDone() As Boolean
    End Function
    ' Return TRUE (1) if there is a device open, and it is in
    ' the state that indicates that no more scans should be requested
    ' at this time.  This call can be used as the test at the *bottom*
    ' of a do-until loop, for multipage scanning:
    '   If TWAIN_OpenDefaultSource() Then
    '      TWAIN_SetMultiTransfer(1)
    '      Do
    '         TWAIN_AcquireToFilename(0, NextFileName())
    '      Until TWAIN_IsDone()
    '      TWAIN_CloseSource()
    '   End If
    '

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SourceName")> _
    Public Shared Function SourceNamePtr() As IntPtr
    End Function
    Public Shared Function SourceName() As String
        SourceName = Marshal.PtrToStringAnsi(SourceNamePtr())
    End Function
    ' Returns a pointer to the name of the currently or last opened source.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetSourceName")> _
    Public Shared Sub GetSourceName(ByVal sName As System.Text.StringBuilder)
    End Sub
    ' Like TWAIN_SourceName, but copies current/last source name into its parameter.
    ' The parameter is a string variable (char array in C/C++).
    ' You are responsible for allocating room for 33 8-bit characters
    ' in the string variable before calling this function.

    '--------- DIB handling utilities ---------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Depth(ByVal hdib As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_BitsPerPixel(ByVal hdib As IntPtr) As Int32
    End Function
    ' 'depth' of image - number of bits used to store one pixel

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PixelType(ByVal hdib As IntPtr) As Int32
    End Function
    ' TWAIN PixelType that describes this DIB: TWPT_BW, TWPT_GRAY, TWPT_RGB,
    ' TWPT_PALETTE, TWPT_CMYK, TWPT_CMY, etc.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Width(ByVal hdib As IntPtr) As Int32
    End Function
    ' Width of DIB, in pixels (columns)
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Height(ByVal hdib As IntPtr) As Int32
    End Function
    ' Height of DIB, in lines (rows)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetResolution(ByVal hdib As IntPtr, ByVal xdpi As Double, ByVal ydpi As Double)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetResolutionInt(ByVal hdib As IntPtr, ByVal xdpi As Int32, ByVal ydpi As Int32)
    End Sub
    ' Sets the horizontal and vertical resolution of the DIB.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_XResolution(ByVal hdib As IntPtr) As Double
    End Function
    ' Horizontal (x) resolution of DIB, in DPI (dots per inch)
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_YResolution(ByVal hdib As IntPtr) As Double
    End Function
    ' Vertical (y) resolution of DIB, in DPI (dots per inch)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_XResolutionInt(ByVal hdib As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_YResolutionInt(ByVal hdib As IntPtr) As Int32
    End Function
    ' Return the nearest integer value to the x or y resolution of an image.

    ' Physical or 'implied' image size
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PhysicalWidth(ByVal hdib As IntPtr, ByVal nUnits As Int32) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PhysicalHeight(ByVal hdib As IntPtr, ByVal nUnits As Int32) As Double
    End Function
    ' Return the width(height), in the specified units, of the given
    ' image, calculated using its pixel width(height) and X(Y) resolution.
    ' If the resolution is 0, these functions return 0.
    ' nUnits is one of the TWUN_ values - see TWAIN_GetCurrentUnits.
    ' nUnits=0 is inches, and nUnits=1 is centimeters(cm).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_RowBytes(ByVal hdib As IntPtr) As Int32
    End Function
    ' Number of bytes needed to store one row of the DIB.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ColorCount(ByVal hdib As IntPtr) As Int32
    End Function
    ' Number of colors in color table of DIB.
    ' Primarily useful for B&W, gray, and palette images.
    ' 16-bit gray, RGB, CMY & CMYK images have no color table: DIB_ColorCount returns 0

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_SamplesPerPixel(ByVal hdib As IntPtr) As Int32
    End Function
    ' Number of 'samples' or components or color channels in each pixel.
    ' B&W and gray pixels have 1 sample, RGB and CMY have 3.
    ' CMYK has 4, and palette-color images are treated as having 3 channels.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_BitsPerSample(ByVal hdib As IntPtr) As Int32
    End Function
    ' Number of bits per 'channel'.  For B&W and gray images this is
    ' the same as the DIB_Depth, because those formats have only one channel.
    ' For palette images, this will be 8, because the color values in a
    ' palette image are stored with 8 bits each for R, G, and B.
    ' For RGB, CMY, and CMYK images, this function returns the number of bits
    ' used to represent each color channel or component - almost always 8, but
    ' EZTwain has a limited ability to handle 16-bit per channel images.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_IsCompressed(ByVal hdib As IntPtr) As Boolean
    End Function
    ' Return 1(True) if image is compressed in memory 0(False) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Compression(ByVal hdib As IntPtr) As Int32
    End Function
    ' Return the TWCP_xxx code representing the compression algorithm
    ' of this image.  Uncompressed images yield TWCP_NONE.



    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Size(ByVal hdib As IntPtr) As Int32
    End Function
    ' Return the size in memory of the given DIB.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadData(ByVal hdib As IntPtr, ByRef pdata As System.Byte, ByVal nbMax As Int32)
    End Sub
    ' Read up to nbMax bytes from the given DIB into the given buffer.
    ' The data is read 'verbatim' from the first byte of the DIB.
    ' To read pixel data, see DIB_ReadRowxxx below.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadRow(ByVal hdib As IntPtr, ByVal r As Int32, ByRef prow As System.Byte)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadRowRGB(ByVal hdib As IntPtr, ByVal r As Int32, ByRef prow As System.Byte)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadRowGray(ByVal hdib As IntPtr, ByVal r As Int32, ByRef prow As System.Byte)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadRowChannel(ByVal hdib As IntPtr, ByVal r As Int32, ByRef prow As System.Byte, ByVal nChannel As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadRowSample(ByVal hdib As IntPtr, ByVal r As Int32, ByRef prow As System.Byte, ByVal nSample As Int32)
    End Sub
    ' Read row r of the given DIB into buffer at prow.
    ' Caller is responsible for ensuring buffer is large enough.
    ' ReadRowRGB always reads 3 bytes (24 bits) for each pixel,
    ' ReadRowGray and ReadRowChannel always read 1 byte (8 bits) per pixel.
    ' Row 0 is the *top* row of the image, as it would be displayed.
    ' The first variant reads the data exactly as-is from the DIB, including
    ' BGR pixels from 24-bit DIBs, 16-bit grayscale, 1-bit B&W, etc.
    ' The RGB variant unpacks every DIB pixel into 3-byte RGB pixels.
    ' The Gray variant converts every pixel to its 8-bit gray value.
    ' Channel codes are: 0=Gray(Luminance), 1=Red, 2=Green, 3=Blue.  See
    ' 'Component codes' below.
    ' Samples are the bytes of the pixel: A grayscale pixel has sample 0,
    ' an RGB image has samples 0, 1 and 2 (which are actually Green, Red and Blue).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadPixelRGB(ByVal hdib As IntPtr, ByVal x As Int32, ByVal y As Int32, ByRef buffer As System.Byte)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadPixelGray(ByVal hdib As IntPtr, ByVal x As Int32, ByVal y As Int32, ByRef buffer As System.Byte)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadPixelChannel(ByVal hdib As IntPtr, ByVal x As Int32, ByVal y As Int32, ByRef buffer As System.Byte, ByVal nChannel As Int32)
    End Sub
    ' Read the value of the pixel at column x row y of the DIB into the buffer.
    ' RGB form reads 3 bytes R,G,B
    ' Gray form reads 1 byte of 'equivalent gray'
    ' Channel form reads 1 byte of channel/component, see COMPONENT_xxx codes.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_WriteRow(ByVal hdib As IntPtr, ByVal r As Int32, ByRef pdata As System.Byte)
    End Sub
    ' Write data from buffer into row r of the given DIB.
    ' Caller is responsible for ensuring buffer and row exist, etc.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_WriteRowChannel(ByVal hdib As IntPtr, ByVal r As Int32, ByRef pdata As System.Byte, ByVal nChannel As Int32)
    End Sub
    ' Write data from buffer into one color channel of row r of the given DIB.
    ' This function should only be used on 24-bit RGB, 32-bit RGBA, 24-bit CMY,
    ' 32-bit CMYK, or 8-bit grayscale images.  Its behavior on any other image is undefined.
    ' Channels are: 0=gray, 1=Red, 2=Green, 3=Blue, 4=Alpha or
    ' 1=C, 2=M, 3=Y, 4=K.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_WriteRowSample(ByVal hdib As IntPtr, ByVal r As Int32, ByRef psrc As System.Byte, ByVal nSample As Int32)
    End Sub
    ' Write row of data into one sample of an image.
    ' Only handles 8-bit data and images with 1 or more samples of 8 bits each.
    ' Channels are somewhat logical properties of an image, samples are
    ' just the bytes in a pixel - sample 0 is byte 0, sample 1 is byte 1, etc.

    ' Safe versions of ReadRow and WriteRow, handy for .NET languages
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_WriteRowSafe(ByVal hdib As IntPtr, ByVal r As Int32, ByRef pdata As System.Byte, ByVal nbMax As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_ReadRowSafe(ByVal hdib As IntPtr, ByVal nRow As Int32, ByRef prow As System.Byte, ByVal nbMax As Int32)
    End Sub

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Allocate(ByVal nDepth As Int32, ByVal nWidth As Int32, ByVal nHeight As Int32) As IntPtr
    End Function
    ' Create a DIB with the given dimensions.  Resolution is set to 0.  A default
    ' color table is provided if depth <= 8.
    ' The image data is uninitialized i.e. garbage.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Create(ByVal nPixelType As Int32, ByVal nWidth As Int32, ByVal nHeight As Int32, ByVal nDepth As Int32) As IntPtr
    End Function
    ' Create a DIB of the given pixel type and dimensions.
    ' If nDepth <= 0, uses the default depth for the given pixel type.
    ' Resolution is set to 0.
    ' For TWPT_GRAY images, a standard black-to-white color table is set.
    ' For TWPT_PALETTE images, a Windows-standard 256-entry color table is set.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_Free(ByVal hdib As IntPtr)
    End Sub
    ' Release the storage of the DIB.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_InUseCount() As Int32
    End Function
    ' Return the number of DIBs 'outstanding' - allocated but not disposed of.
    ' Note that a DIB that is put on the clipboard becomes the property of the
    ' clipboard and is considered 'disposed of'.
    ' This function can be used to detect leaks in application DIB management.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Copy(ByVal hdib As IntPtr) As IntPtr
    End Function
    ' Create and return a byte-for-byte copy of a DIB.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Equal(ByVal hdib1 As IntPtr, ByVal hdib2 As IntPtr) As Boolean
    End Function
    ' Return TRUE (1) if the two dibs are valid, have the same parameters,
    ' and are the same color pixel-for-pixel.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_MaxError(ByVal hdib1 As IntPtr, ByVal hdib2 As IntPtr) As Int32
    End Function
    ' return the largest difference between two samples in the two images.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetGrayColorTable(ByVal hdib As IntPtr)
    End Sub
    ' Fill the DIB's color table with a gray ramp - so color 0 is black, and
    ' the last color (largest pixel value) is white.  No effect if depth > 8.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetColorTableRGB(ByVal hdib As IntPtr, ByVal i As Int32, ByVal R As Int32, ByVal G As Int32, ByVal B As Int32)
    End Sub
    ' Set the ith entry in the DIB's color table to the specified color.
    ' R G and B range from 0 to 255.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_IsVanilla(ByVal hdib As IntPtr) As Boolean
    End Function
    ' TRUE if in this DIB, pixel value 0 means 'white'.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_IsChocolate(ByVal hdib As IntPtr) As Boolean
    End Function
    ' TRUE if in this DIB, pixel value 0 means 'black'.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ColorTableR(ByVal hdib As IntPtr, ByVal i As Int32) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ColorTableG(ByVal hdib As IntPtr, ByVal i As Int32) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ColorTableB(ByVal hdib As IntPtr, ByVal i As Int32) As Int32
    End Function
    ' Return the R,G, or B component of the ith color table entry of a DIB.
    ' If i < 0 or >= DIB_ColorCount(hdib), returns 0.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_FlipVertical(ByVal hdib As IntPtr)
    End Sub
    ' Flip (mirror) the bitmap vertically.
    ' Top and bottom rows are exchanged, etc.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_FlipHorizontal(ByVal hdib As IntPtr)
    End Sub
    ' Flip (mirror) the bitmap horizontally.
    ' Leftmost pixels become rightmost, etc.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_Rotate180(ByVal hdib As IntPtr)
    End Sub
    ' Rotate image 180 degrees

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Rotate90(ByVal hOld As IntPtr, ByVal nSteps As Int32) As IntPtr
    End Function
    ' Return a copy of hOld rotated clockwise nSteps * 90 degrees.
    ' If nSteps is 0, the result is a copy of hOld.
    ' Negative values of nSteps rotate counterclockwise.
    ' Note that *hOld is not destroyed*

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_Fill(ByVal hdib As IntPtr, ByVal R As Int32, ByVal G As Int32, ByVal B As Int32)
    End Sub
    ' Fill the DIB with the specified color

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_Negate(ByVal hdib As IntPtr)
    End Sub

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_AdjustBC(ByVal hdib As IntPtr, ByVal nB As Int32, ByVal nC As Int32)
    End Sub
    ' *** BETA - new in 3.08b8 - use with caution.
    ' Adjust the brightness and/or contrast of the image.
    ' nB and nC are -1000 to 1000, with a value of 0 meaning 'no change'.
    ' Positive nB push all pixels toward white, negative toward black.
    ' Positive nC push all pixels away from mid-value, toward black and white.
    ' Negative nC pushes all pixels toward the mid-value.
    ' Works on grayscale, RGB, CMY(K) images - no effect on B&W and palette.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_AutoContrast(ByVal hdib As IntPtr) As Boolean
    End Function
    ' Automatically adjust the values in the image to make
    ' the dominant light color into white, and the primary dark tone into black.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_Convolve(ByVal hdibDst As IntPtr, ByVal hdibKernel As IntPtr, ByVal dNorm As Double, ByVal nOffset As Int32)
    End Sub
    ' Apply hdibKernel as a convolution kernel to hdibDst.
    ' At each pixel in hdibDst, hdibKernel is convolved with the neighborhood
    ' and the result is stored back into hdibDst.
    ' The point value of the convolution is normalized by dividing by dNorm, and
    ' then nOffset is added, before clipping to the pixel range of hdibDst.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_Correlate(ByVal hdibDst As IntPtr, ByVal hdibKernel As IntPtr)
    End Sub
    ' Similar to DIB_Convolve, but performs a correlation between hdibDst and hdibKernel,
    ' assuming that hdibKernel is image data (preferably grayscale), and putting
    ' the result into hdibDst.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_CrossCorrelate(ByVal hdibDst As IntPtr, ByVal hdibTemplate As IntPtr, ByVal dScale As Double, ByVal nMin As Int32)
    End Sub
    ' Similar to DIB_Convolve, but performs a cross-correlation between hdibDst and hdibTemplate,
    ' assuming that hdibTemplate is grayscale image data, and putting
    ' the result into hdibDst.  In the output, a value of 255 signifies perfect correlation,
    ' 0 signifies perfect non-correlation (actually, a perfect opposite).
    ' All output values are divided by dScale.
    ' If nMin > 0, the correlation at each output pixel stops as soon as the value at that
    ' pixel is known to be <= nMin.  If you know that the values of interest are (say) > 200,
    ' setting a dMin of 128 can speed up the correlation greatly.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_HorizontalDifference(ByVal hdib As IntPtr)
    End Sub

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_HorizontalCorrelation(ByVal hdib As IntPtr)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_VerticalCorrelation(ByVal hdib As IntPtr)
    End Sub

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_MedianFilter(ByVal hdib As IntPtr, ByVal W As Int32, ByVal H As Int32, ByVal nStyle As Int32)
    End Sub
    ' Apply a median filter to hdib using an W x H neighborhood.
    ' nStyle is currently ignored, but should be 0 for future compatibility.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_MeanFilter(ByVal hdib As IntPtr, ByVal W As Int32, ByVal H As Int32)
    End Sub
    ' Replace each pixel with the average of a W x H pixel neighborhood.
    ' We recommend you use odd value for W and H.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_Smooth(ByVal hdib As IntPtr, ByVal sigma As Double, ByVal opacity As Double)
    End Sub
    ' Apply a (gaussian) smoothing filter to the image.
    ' sigma is the controlling parameter of the Gaussian
    ' G(x,y) = exp(-(x^2+y^2) / 2*sigma^2) / (2 * pi * sigma^2)
    ' opacity is the fraction of the filter output that is blended
    ' back into the image i.e. out = in*(1-opacity) + f(in)*opacity

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ScaledCopy(ByVal hOld As IntPtr, ByVal w As Int32, ByVal h As Int32) As IntPtr
    End Function
    ' Create and return a new image - which is a copy of hOld
    ' but scaled (resampled) to have width w and height h.
    ' The input image must be of type TWPT_BW, TWPT_GRAY, or TWPT_RGB.
    ' If the input image is of type TWPT_BW, the returned image will be
    ' 8-bit grayscale.
    ' Otherwise the output image has the same type and depth as the input.
    ' *Don't forget to DIB_Free the old DIB when you are done with it.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Resample(ByVal hOld As IntPtr, ByVal xdpi As Double, ByVal ydpi As Double) As IntPtr
    End Function
    ' Return a new image which is a copy of the old image, but resampled
    ' to the specified resolution.
    ' "Resampling" is the technical term for recomputing the pixels of
    ' an image, when you want to change the number of pixels in the image
    ' but not the physical size (like 8.5" x 11").
    ' If you resample from 300DPI to 100DPI, you will have 1/3 as many rows,
    ' 1/3 as many columns, 1/9 as many pixels - but the pixels will be
    ' marked in the image as being 3 times as 'wide' and 'tall' - so the
    ' physical size of the image stays the same.
    ' This is the same as DIB_ScaledCopy, just looked at in a different way.
    ' DIB_Resample will fail if the input image as either resolution <= 0,
    ' or if either xdpi or ydpi is <= 0.  It can also fail with insufficient memory.
    ' Remember to DIB_Free the old DIB when you are done with it.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_RegionCopy(ByVal hOld As IntPtr, ByVal leftx As Int32, ByVal topy As Int32, ByVal w As Int32, ByVal h As Int32, ByVal FillByte As Int32) As IntPtr
    End Function
    ' Create and return a portion of DIB hOld.  The copied region is a rectangle
    ' w pixels wide, h pixels high, starting at (x, y) in the hOld image,
    ' where (0,0) is the upper-left corner of hOld, visually.
    ' Pixels that don't fit into the new DIB are discarded.
    ' (So this function can be used to crop an image.)
    ' If the new DIB is taller or wider than the old, the new
    ' pixels are filled with bytes = fill.  Common values for
    ' fill are:
    '       -1 (or 255 or 0xFF) which fills with 1's producing white
    '   0 which produces black fill.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_AutoCrop(ByVal hOld As IntPtr, ByVal nOptions As Int32) As IntPtr
    End Function
    ' Return a copy of the image in hOld, with the surrounding border
    ' of uniform color (if there is one) removed.
    ' Uses RegionCopy (above).
    ' After this call, remember to DIB_Free(hOld) if you don't need it.
    ' nOptions is currently unused and must be 0 (zero).

    Friend Const AUTOCROP_DARK As Int32 = 1
    Friend Const AUTOCROP_LIGHT As Int32 = 2
    Friend Const AUTOCROP_EDGE As Int32 = 4

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_GetCropRect(ByVal hdib As IntPtr, ByVal nOptions As Int32, ByRef cropx As Int32, ByRef cropy As Int32, ByRef cropw As Int32, ByRef croph As Int32) As Boolean
    End Function
    ' Return a suggested crop rectangle to remove a dark border from the image.
    ' The rectangle is defined by an upper-left point and a width and height, in pixels.
    ' (As needed by DIB_RegionCopy above.)
    ' nOptions is currently unused and must be 0.
    ' DIB_AutoCrop uses this function to decide what to crop.
    ' A return of FALSE means no crop rectangle was found - generally this means
    ' that the image has content that extends to the edges, or has no definite borders
    ' of dark color.  For convenience, when this function returns FALSE it
    ' still returns a valid crop rectangle containing the entire image.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_AutoDeskew(ByVal hOld As IntPtr, ByVal nOptions As Int32) As IntPtr
    End Function
    ' Returns a copy of the image in hOld, possibly 'deskewed'.
    ' If it can be determined that the input image is consistently
    ' skewed (rotated by a small angle) then the returned image is rotated
    ' to eliminate that skew.
    ' The depth and pixel type of the image are not changed.
    ' The dimensions of the returned image may be slightly changed.
    ' nOptions is currently unused and must be 0 (zero).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_DeskewAngle(ByVal hdib As IntPtr) As Double
    End Function
    ' Compute and return the small clockwise rotation that would best
    ' 'deskew' the given image.  The return value is that angle
    ' in radians.  Only rotations in the range +-4 degrees are considered.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SkewByDegrees(ByVal hdib As IntPtr, ByVal dAngle As Double)
    End Sub
    ' Skew the given image clockwise in place by the specified angle (in degrees)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ConvertToPixelType(ByVal hOld As IntPtr, ByVal nPT As Int32) As IntPtr
    End Function
    ' Create and return a new DIB containing the hOld image converted
    ' to the specified pixel type.  Supported pixel types are:
    ' TWPT_BW, TWPT_GRAY, TWPT_RGB, TWPT_PALETTE, TWPT_CMY or TWPT_CMYK.
    ' When converting to black & white (TWPT_BW) the default conversion
    ' is simple thresholding - each pixel is converted to grayscale,
    ' then values 0..127 => Black, 128..255 => White.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ConvertToFormat(ByVal hOld As IntPtr, ByVal nPT As Int32, ByVal nBPP As Int32) As IntPtr
    End Function
    ' Create and return a new DIB containing the hOld image converted
    ' to the specified pixel type and bits per pixel.
    ' Unsupported and impossible combinations cause a NULL return.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_SmartThreshold(ByVal hdib As IntPtr) As IntPtr
    End Function
    ' Apply automatic, adaptive thresholding to hdib, return
    ' the resulting 1-bit image.  This function is optimized for
    ' thresholding scanned text.
    ' ** Remember to free the input image if you are done with it.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_SimpleThreshold(ByVal hdib As IntPtr, ByVal nT As Int32) As IntPtr
    End Function
    ' Threshold hdib against nT and return the resulting 1-bit image.
    ' nT should be in the range 0 to 255.
    ' Pixels that are darker than nT become black in the output,
    ' pixels that are equal to or lighter than nT become white.
    ' ** Remember to free the input image if you are done with it.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_SetConversionThreshold(ByVal nT As Int32) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ConversionThreshold() As Int32
    End Function
    ' Set/Get the threshold used by DIB_ConvertToPixelType above
    ' when converting to B&W.  The default value is 128 which means '50%'.
    ' Pixels lighter than 50% => white, darker => black.
    ' DIB_SetConversionThreshold returns the previous value of the threshold.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_FindAdaptiveGlobalThreshold(ByVal hdib As IntPtr) As Int32
    End Function
    ' Find the adaptive threshold for input image

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ErrorDiffuse(ByVal hdib As IntPtr) As IntPtr
    End Function
    ' Create and return a new DIB containing the input image rendered
    ' to 1-bit B&W using error diffusion. The input image is not modified.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetConversionColorCount(ByVal n As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ConversionColorCount() As Int32
    End Function
    ' Set/Get the number of colors that will be used in the next
    ' call to DIB_ConvertToPixelType or DIB_ConvertToFormat, if
    ' the output type is TWPT_PALETTE.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ScaleToGray(ByVal hdibOld As IntPtr, ByVal nRatio As Int32) As IntPtr
    End Function
    ' Create and return a new DIB containing the hdibOld image
    ' converted to grayscale and reduced in width & height by nRatio.
    ' Works well on B&W images.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Thumbnail(ByVal hdibSource As IntPtr, ByVal MaxWidth As Int32, ByVal MaxHeight As Int32) As IntPtr
    End Function
    ' Return a DIB containing a copy of hdibSource, scaled so that its width
    ' is no more than MaxWidth, and height is no more than MaxHeight.
    ' B&W images are converted to grayscale thumbnails.
    ' Remember to DIB_Free hdibSource and the thumbnail, when you are done with them.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SwapRedBlue(ByVal hdib As IntPtr)
    End Sub
    ' For 24-bit DIB only, exchange R and B components of each pixel.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_CreatePalette(ByVal hdib As IntPtr) As IntPtr
    End Function
    ' Create and return a logical palette to be used for drawing the DIB.
    ' For 1, 4, and 8-bit DIBs the palette contains the DIB color table.
    ' For 24-bit DIBs, a default halftone palette is returned.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetColorModel(ByVal hdib As IntPtr, ByVal nCM As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ColorModel(ByVal hdib As IntPtr) As Int32
    End Function
    Friend Const EZT_CM_RGB As Int32 = 0
    Friend Const EZT_CM_GRAY As Int32 = 3
    Friend Const EZT_CM_CMYK As Int32 = 5

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetColorCount(ByVal hdib As IntPtr, ByVal n As Int32)
    End Sub

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_Blt(ByVal hdibDst As IntPtr, ByVal dx As Int32, ByVal dy As Int32, ByVal hdibSrc As IntPtr, ByVal sx As Int32, ByVal sy As Int32, ByVal w As Int32, ByVal h As Int32, ByVal uRop As Int32)
    End Sub
    ' Transfer pixels from hdibSrc into hdibDst, starting at
    ' (dx,dy) in the destination, and (sx,sy) in the source,
    ' and transferring w columns x h rows.
    ' Any pixels that fall outside the actual bounds of the source
    ' and destination DIBs are ignored.
    ' The operations available are:
    Friend Const EZT_ROP_COPY As Int32 = 0
    Friend Const EZT_ROP_OR As Int32 = 1
    Friend Const EZT_ROP_AND As Int32 = 2
    Friend Const EZT_ROP_XOR As Int32 = 3
    Friend Const EZT_ROP_ANDNOT As Int32 = &H12

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_BltMask(ByVal hdibDst As IntPtr, ByVal dx As Int32, ByVal dy As Int32, ByVal hdibSrc As IntPtr, ByVal sx As Int32, ByVal sy As Int32, ByVal w As Int32, ByVal h As Int32, ByVal uRop As Int32, ByVal hdibMask As IntPtr)
    End Sub
    ' Like DIB_Blt, but hdibMask contains an 8-bit alpha mask that controls
    ' how hdibSrc and hdibDst pixels are blended.  hdibMask must be the
    ' same size as hdibSrc, and be 8-bits deep.
    ' NOTE: The only uRop currently supported is EZT_ROP_COPY

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_PaintMask(ByVal hdibDst As IntPtr, ByVal dx As Int32, ByVal dy As Int32, ByVal R As Int32, ByVal G As Int32, ByVal B As Int32, ByVal sx As Int32, ByVal sy As Int32, ByVal w As Int32, ByVal h As Int32, ByVal uRop As Int32, ByVal hdibMask As IntPtr)
    End Sub
    ' Like DIB_BltMask - but paints a solid color into the destination DIB
    ' using hdibMask as a mask or stencil.  The mask must be an 8-bit
    ' grayscale image. The each mask pixel controls how much paint is mixed
    ' into the corresponding destination pixel: white=100%, black=0%.
    ' if w == -1 or h == -1 it means "as much as possible"
    ' NOTE: The only uRop currently supported is EZT_ROP_COPY
    ' See the User Guide for details.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_DrawLine(ByVal hdibDst As IntPtr, ByVal x1 As Int32, ByVal y1 As Int32, ByVal x2 As Int32, ByVal y2 As Int32, ByVal R As Int32, ByVal G As Int32, ByVal B As Int32)
    End Sub

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_DrawText(ByVal hdibDst As IntPtr, ByVal sText As String, ByVal leftx As Int32, ByVal topy As Int32, ByVal w As Int32, ByVal h As Int32)
    End Sub
    ' Draw the text string into the DIB inside the given rectangle.
    ' If w or h is 0, the rectangle is extended to the bottom or right of the DIB.
    ' Default height is 14 pixels.  Default typeface is "Arial".
    ' Default color is black (R=G=B=0)
    ' See the following functions to override the default text settings.

    ' The following functions modify the default settings for DIB_DrawText:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetTextColor(ByVal R As Int32, ByVal G As Int32, ByVal B As Int32)
    End Sub

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetTextAngle(ByVal nDegrees As Int32)
    End Sub
    ' Set the rotation of text within the drawing rectangle, clockwise.
    ' NOTE: Currently only multiples of 90 degrees are supported.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetTextHeight(ByVal nH As Int32)
    End Sub
    ' Set the text character height in pixels.
    ' If you want to set the text height in physical units (inches)
    ' multiply the physical height in inches by the DIB_YResolution.
    ' Note! Some files have resolution=0, which can often be treated as 72dpi

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetTextFace(ByVal sTypeface As String)
    End Sub
    ' Specify a typeface - Use a typeface that is available on the host system,
    ' or use a standard face such as Arial, MS San Serif, MS Serif.
    ' You can also specify "Courier" or "Times" as shortcuts for the classic
    ' fixed-width and serif fonts.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetTextFormat(ByVal nFlags As Int32)
    End Sub
    ' Sets text format according to the following flags.  The default
    ' format is normal, top, left
    Friend Const EZT_TEXT_NORMAL As Int32 = &H0
    Friend Const EZT_TEXT_BOLD As Int32 = &H1
    Friend Const EZT_TEXT_ITALIC As Int32 = &H2
    Friend Const EZT_TEXT_UNDERLINE As Int32 = &H4
    Friend Const EZT_TEXT_STRIKEOUT As Int32 = &H8
    Friend Const EZT_TEXT_BOTTOM As Int32 = &H100
    Friend Const EZT_TEXT_VCENTER As Int32 = &H200
    Friend Const EZT_TEXT_TOP As Int32 = &H0
    Friend Const EZT_TEXT_LEFT As Int32 = &H0
    Friend Const EZT_TEXT_CENTER As Int32 = &H1000
    Friend Const EZT_TEXT_RIGHT As Int32 = &H2000
    Friend Const EZT_TEXT_WRAP As Int32 = &H4000


    '/////////////////////////////////////////////////////////////////////
    ' Image viewing services

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_View(ByVal hdib As IntPtr, ByVal sTitle As String, ByVal hwndParent As IntPtr) As Int32
    End Function
    ' Display the given image in a window with the given title.
    ' hwndParent is the window handle of the parent window - if you
    ' use 0 (NULL) for this parameter, EZTwain uses the active window
    ' of the application if there is one, or no parent window.
    ' By default, the window contains just an [OK] button.
    ' The style of the window is a resizable dialog box.
    ' 0    = the [Cancel] button was pressed.
    ' 1    = the [OK] button was pressed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_SetViewOption(ByVal sOption As String, ByVal sValue As String) As Boolean
    End Function
    ' Same as TWAIN_SetViewOption.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_SetViewImage(ByVal hdib As IntPtr) As Boolean
    End Function
    ' If the image viewer is open, change the displayed image to this one.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_IsViewOpen() As Boolean
    End Function
    ' Return True if the image-view window is open, False otherwise.
    ' Note that the image viewer can be hidden, so it could be open
    ' and not be visible.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ViewClose() As Boolean
    End Function
    ' Close the image viewer window, if it is open.
    ' Only applies if the image viewer has been opened with the modeless option.
    ' Same as TWAIN_ViewClose.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_DrawOnWindow(ByVal hdib As IntPtr, ByVal hwnd As IntPtr)
    End Sub
    ' Draw the DIB on the window.
    ' The image is scaled to just fit inside the window, while
    ' keeping the correct aspect ratio.  Any part of the window
    ' not covered by the image is left untouched (so it will normally
    ' be filled with the window's background color.)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_DrawToDC(ByVal hdib As IntPtr, ByVal hDC As IntPtr, ByVal dx As Int32, ByVal dy As Int32, ByVal w As Int32, ByVal h As Int32, ByVal sx As Int32, ByVal sy As Int32)
    End Sub
    ' Draws DIB on a device context.
    ' You should call CreateDibPalette, select that palette
    ' into the DC, and do a RealizePalette(hDC) first.

    '/////////////////////////////////////////////////////////////////////
    ' Printing services

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_SpecifyPrinter(ByVal sPrinterName As String) As Boolean
    End Function
    ' Specify the printer to be used when printing to the 'default printer'
    ' with the following functions.
    ' This does not change the user's default printer - it just tells
    ' EZTwain which printer to use as 'default'.
    ' Setting the printer name to NULL or the empty string tells EZTwain to
    ' use the user's default printer as its default printer.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_EnumeratePrinters() As Int32
    End Function
    ' Return the number of available printers

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="DIB_PrinterName")> _
    Public Shared Function DIB_PrinterNamePtr(ByVal i As Int32) As IntPtr
    End Function
    Public Shared Function DIB_PrinterName(ByVal i As Int32) As String
        DIB_PrinterName = Marshal.PtrToStringAnsi(DIB_PrinterNamePtr(i))
    End Function
    ' Return the name of the ith available printer, as found
    ' by a previous call to DIB_EnumeratePrinters.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_GetPrinterName(ByVal i As Int32, ByVal PrinterName As System.Text.StringBuilder) As Boolean
    End Function
    ' Get the name of the ith available printer, as found by a previous
    ' call to DIB_EnumeratePrinters.
    ' You must allocate 256 characters for the printer name, and in many
    ' languages (especially Basic dialects) you must initialize the
    ' PrinterName variable with 256 spaces.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetPrintToFit(ByVal bYes As Boolean)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_GetPrintToFit() As Boolean
    End Function
    ' Get/Set the 'Print To Fit' flag.
    ' When this flag is non-zero, EZTwain reduces the size of images
    ' to fit within the printer page.  This only affects images that
    ' are too large to fit on the page.
    ' By default, this flag is FALSE (0)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Print(ByVal hdib As IntPtr, ByVal sJobname As String) As Int32
    End Function
    ' Prompt the user with a Print Dialog, then print the DIB.
    ' Normally prints the DIB at 'actual size' - meaning the resolution
    ' values are used to convert the width and height from pixels to physical
    ' units (e.g. inches.)
    ' If the PrintToFit flag (see DIB_SetPrintToFit) is set and the image
    ' is larger than the printer page, the image is scaled to fit on the page.
    ' If the DIB has resolution values of 0, 72 DPI is assumed.
    ' The image is printed centered on the page.
    ' Return values:
    '   0  success, no error
    '  -2  specified printer not recognized or could not be opened
    '  -3  invalid DIB handle (null, or DIB has been freed, or isn't a DIB handle)
    '  -4  could not start document or start page error during printing
    ' -10  user cancelled a dialog (probably the Print dialog)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PrintNoPrompt(ByVal hdib As IntPtr, ByVal sJobname As String) As Int32
    End Function
    ' Identical to DIB_Print, but prints on the default printer with
    ' default settings - the user is not prompted.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_PrintFile")> _
    Public Shared Function PrintFile(ByVal sFilename As String, ByVal sJobname As String, ByVal bNoPrompt As Boolean) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PrintFile(ByVal sFilename As String, ByVal sJobname As String, ByVal bNoPrompt As Boolean) As Int32
    End Function
    ' Print the specified file as a print job with the specified job name.
    ' If the filename is null or empty, the user is prompted to select a file.
    ' If the jobname is null or empty, the actual filename is used as the jobname.
    ' If bNoPrompt is non-zero (True) the job is sent to the default printer,
    ' If bNoPrompt is zero (False) the user is prompted with the standard Print dialog.

    ' Printing - Multi-Page
    '

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PrintArray(ByVal ahdib As IntPtr(), ByVal nCount As Int32, ByVal sJobname As String, ByVal bNoPrompt As Boolean) As Int32
    End Function
    ' Print the first nCount images in the array ahdib, under the given print-job name.
    '
    ' If the job-name parameter is NULL or the empty string, the application title is used.
    ' If bNoPrompt is TRUE(non-zero), prints to the default printer without prompting the user,
    ' If bNoPrompt is FALSE(0) this function displays the standard print dialog.
    '
    ' Return value is same as DIB_Print above.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SetNextPrintJobPageCount(ByVal nPages As Int32)
    End Sub
    ' If you are about to call DIB_PrintJobBegin, you can call this function
    ' *before* calling that one, to set the page count for the next print job.
    ' This allows the print dialog to enable the page-range controls, so the
    ' user can designate a range of pages to print.
    '
    ' Do not call this function unless you are calling DIB_PrintJobBegin directly.
    '
    ' A page count of 0 or less means 'unknown page count', which disables
    ' the page-range controls.
    ' If you enable print-range selection in the print dialog, EZTwain
    ' automatically suppresses printing of all non-selected pages.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PrintJobBegin(ByVal sJobname As String, ByVal bUseDefaultPrinter As Boolean) As Int32
    End Function
    ' Begin creating a multi-page print job.
    '
    ' Jobname is the name of the print job.
    ' The jobname appears in the job-queue of the printer.
    ' In some environments it also appears on a job-separator
    ' page that is printed out ahead of each job.
    ' If Jobname is null or empty, the application title is used.
    ' (See TWAIN_SetAppTitle)
    '
    ' If bUseDefaultPrinter is true (non-zero) the default printer
    ' is used, otherwise the user is prompted with a standard Print dialog.
    '
    ' If you have called DIB_SetNextPrintJobPageCount (above) then the print
    ' dialog will offer the user the option of specifying a range of pages
    ' to print.  Otherwise that option is disabled and all pages are printed.
    '
    ' If there is already a print job open when this function is called,
    ' it calls DIB_PrintJobEnd() to close that job before starting the new one.
    '
    ' Return values:
    '  0       success
    ' -2       could not open/access printer
    ' -4       printing output error
    '-10       user cancelled Print dialog

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PrintPage(ByVal hdib As IntPtr) As Int32
    End Function
    ' Add a page to the current print job.
    '
    ' Only valid after a successful call to DIB_PrintJobBegin and
    ' before the matching DIB_PrintJobEnd.
    '
    ' See DIB_Print for more details.
    '  0       success
    ' -3       the DIB is null or invalid
    ' -4       printing output error
    ' -5       no print job is open

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PrintJobEnd() As Int32
    End Function
    ' End the current print job and release it for printing.
    ' (Some environments will start printing as soon as a page is available.)
    '  0       success
    ' -4       printing output error
    ' -5       no print job is open

    '/////////////////////////////////////////////////////////////////////
    ' Clipboard functions
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PutOnClipboard(ByVal hdib As IntPtr) As Boolean
    End Function
    ' Place DIB on the clipboard (format CF_DIB)
    ' ** IMPORTANT ** After this call, the clipboard owns the
    ' DIB and you do not - do not attempt any
    ' further operations on the hdib handle.
    ' Treat this call just as you would a call to DIB_Free.
    ' Returns TRUE(1) for success, FALSE(0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_CanGetFromClipboard() As Boolean
    End Function
    ' Return TRUE(1) if there is something on the clipboard that
    ' can be delivered as a DIB (by DIB_GetFromClipboard below.)
    ' Return FALSE(0) if not.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_GetFromClipboard() As IntPtr
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_FromClipboard() As IntPtr
    End Function
    ' Create and return a DIB with the contents of the clipboard.
    ' This is the first step of a 'paste' function for images.
    ' Returns NULL in case of error, or if no image on clipboard.

    ' Working with a DIB through a DC
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_OpenInDC(ByVal hdib As IntPtr, ByVal hdc As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_CloseInDC(ByVal hdib As IntPtr, ByVal hdc As IntPtr)
    End Sub

    ' DIB File I/O
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToFilename(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    ' Write image to file, using format implied by the filename extension.
    '
    ' If the filename is NULL or points to a null string, the user is
    ' prompted for the filename and format with a standard Windows
    ' file-save dialog.
    '
    ' If the final filename has a standard extension (.bmp, .jpg, .jpeg, .tif,
    ' .tiff, .png, .pdf, .gif, .dcx) then the file is saved in that format.
    ' Otherwise, the current SaveFormat is used - see TWAIN_SetSaveFormat.
    '
    ' Return values:
    '        0      success
    '       -1      user cancelled File Save dialog
    '       -2      file open error (invalid path or name, or access denied)
    '       -3      a) image is invalid (null or invalid DIB handle)
    '      b) support for the save format is not configured
    '      c) DIB format incompatible with save format e.g. B&W to JPEG.
    '       -4      writing data failed, possibly output device is full
    '  -5  other unspecified internal error

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToBmp(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToBmpFile(ByVal hdib As IntPtr, ByVal fh As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToJpeg(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToPng(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToTiff(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToPdf(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToGif(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToDcx(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    ' Note: a return value of -3 indicates an invalid hdib handle, or
    ' 'no support for this format'.  -3 is also returned when attempting
    ' to write a Jpeg file from an image that is not 24-bit color or
    ' 8-bit grayscale.  1-bit B&W images cannot be saved as JPEG.
    ' 24-bit color images are 'quantized' to 8-bit color when written to GIF.
    ' All image types are converted to 1-bit B&W when written to DCX.
    ' Other internal errors will return -5, including insufficient memory.
    ' Check TWAIN_LastErrorCode for more details (maybe)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_LoadFromFilename(ByVal sFileName As String) As IntPtr
    End Function
    ' Load an image from a file and return its handle.
    ' The file can be in any format supported by EZTwain Pro.
    ' If the file is multipage, normally this function loads page 0,
    ' but a preceding call to DIB_SelectPageToLoad changes that.
    ' A return of NULL(0) indicates failure, see TWAIN_LastErrorCode
    ' and related functions for more details.
    ' If the filename is an empty string (or NULL) the user is prompted
    ' with a standard file-open dialog.
    ' EZTwain should read any variant of its supported formats,
    ' except for PDF: We only claim to support reading images
    ' from PDFs if they were created by EZTwain Pro.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_FormatOfFile(ByVal sFileName As String) As Int32
    End Function
    ' Returns the TWFF_ code for the format of the specified file.
    ' A return < 0 indicates 'unrecognized format' or some error
    ' when opening or reading the file.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_SelectPageToLoad(ByVal nPage As Int32)
    End Sub
    ' For use when loading multipage files.  Tells DIB_LoadFromFilename
    ' and DIB_LoadFromBuffer which page to load next, from a multipage file.
    ' Default is page 0 (first page in file).
    ' This value is reset to 0 after any call that tries to load a page.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_GetFilePageCount(ByVal sFileName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_FilePageCount(ByVal sFileName As String) As Int32
    End Function
    ' Return the number of pages in the specified file.
    ' If the file is a recognized multipage format
    ' (TIFF, PDF, DCX), the pages in the file are counted.
    ' All other recognized formats return a page count of 1.
    ' If the file cannot be opened, read, recognized, etc.
    ' this function records an error and returns -1.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_LoadPage(ByVal sFileName As String, ByVal nPage As Int32) As IntPtr
    End Function
    ' Short for DIB_SelectPageToLoad, DIB_LoadFromFilename.
    ' Load the specified page from the specified file.
    ' Page 0 is the first page in a file.  Multiple
    ' pages are only supported in TIFF, PDF and DCX files, all other file
    ' formats have a single page, page #0.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_LoadArrayFromFilename(ByVal ahdib As IntPtr(), ByVal nMax As Int32, ByVal sFilename As String) As Int32
    End Function
    ' Load up to nMax images as DIBs into an array, reading from the specified file.
    ' If filename is null or the empty string, the user is prompted to select a file.
    '
    ' If the user is prompted and cancels, this function returns -10.
    ' Otherwise if successful it returns the number of pages (images) loaded.
    ' Otherwise it returns -1 and you should call TWAIN_ReportLastError, TWAIN_LastErrorCode,etc.
    '
    ' If this function returns < 0, the first nMax entries of the DIB array will be NULL (0).
    ' If returns N >= 0, the first N entries of the DIB array will
    ' contain handles to DIBs representing the first N images in the file.
    ' The remaining nMax-N entries in the DIB array will be NULL (0).
    '
    ' Make sure you eventually call DIB_Free on all the loaded DIBs!

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_LoadPagesFromFilename(ByVal ahdib As IntPtr(), ByVal start As Int32, ByVal count As Int32, ByVal sFilename As String) As Int32
    End Function

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_FormatOfBuffer(ByRef pBuffer As System.Byte, ByVal nBytes As Int32) As Int32
    End Function
    ' Assuming the buffer contains something like an image file, return
    ' the format implied by the leading bytes.
    ' nBytes = number of bytes of data in buffer.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_PageCountOfBuffer(ByRef pBuffer As System.Byte, ByVal nBytes As Int32) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_BufferPageCount(ByRef pBuffer As System.Byte, ByVal nBytes As Int32) As Int32
    End Function
    ' Assuming the buffer contains something like an image file, return
    ' the number of pages (images technically) in it.
    ' nBytes = number of bytes of data in buffer.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_LoadFromBuffer(ByRef pBuffer As System.Byte, ByVal nBytes As Int32) As IntPtr
    End Function
    ' Load an image from a buffer, presumably formatted like an image file.
    ' If DIB_SelectPageToLoad was called just before, the
    ' designated page is loaded from the buffer.
    ' nBytes = number of bytes of data in buffer.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_LoadPageFromBuffer(ByRef pBuffer As System.Byte, ByVal nBytes As Int32, ByVal nPage As Int32) As IntPtr
    End Function
    ' Load the specified page from a buffer - the buffer must contain an image
    ' file.  If the image format is one that can hold only one image, the page
    ' number is ignored.
    ' nBytes = number of bytes of data in buffer.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_LoadArrayFromBuffer(ByVal ahdib As IntPtr(), ByVal nMax As Int32, ByRef pBuffer As System.Byte, ByVal nBytes As Int32) As Int32
    End Function
    ' Load up to nMax images as DIBs into an array, reading from a file in memory.
    ' pBuffer is the address of the buffer (memory block) holding the file to read.
    ' nBytes is the number of bytes of data in the buffer.
    '
    ' Returns the number of images loaded if successful, otherwise
    ' it returns -1 and you should call TWAIN_ReportLastError, TWAIN_LastErrorCode, or similar.
    '
    ' Make sure you eventually call DIB_Free on all the loaded DIBs.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_LoadFaxData(ByVal hdib As IntPtr, ByRef pBuffer As System.Byte, ByVal nBytes As Int32, ByVal nFlags As Int32) As Int32
    End Function
    ' Load a DIB's contents from a buffer of CCITT fax-encoded data.
    ' pBuffer is the address of the buffer in memory.
    ' nBytes is the number of bytes of data in the buffer.
    ' nFlags are decoding options:
    ' Override with flags:
    Friend Const FAX_GROUP3_2D As Int32 = &H20
    Friend Const FAX_GROUP4 As Int32 = &H40
    Friend Const FAX_BYTE_ALIGNED As Int32 = &H80
    Friend Const FAX_REQUIRE_EOLS As Int32 = &H100
    Friend Const FAX_EXPECT_EOB As Int32 = &H200
    Friend Const FAX_VANILLA As Int32 = &H400
    ' default is Group3 1D, chocolate, not byte-aligned, EOLs not required, EOB not expected.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteToBuffer(ByVal hdib As IntPtr, ByVal nFormat As Int32, ByRef pBuffer As System.Byte, ByVal nbMax As Int32) As Int32
    End Function
    ' Write the image into the buffer in the format, not more than nbMax bytes.
    ' The return value is the actual size of the image - this may be more or less
    ' than nbMax.  If the return value > nbMax, it means only part of the image
    ' was written, and the buffer needs to be bigger.
    ' If pBuffer is NULL, no data is written - the function just returns the required
    ' buffer size in bytes.
    ' A return value of <= 0 indicates an error, such as
    '   The image is invalid (null or invalid DIB handle)
    '   The format is unrecognized, not supported, not installed, etc.
    '   You can't save that image in that format e.g. B&W image to JPEG format.
    '   Insufficient memory for temporary data structures (or corrupted heap)
    '   Other internal failure.
    ' You can call TWAIN_LastErrorCode and similar functions for more details.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteArrayToBuffer(ByVal ahdib As IntPtr(), ByVal n As Int32, ByVal nFormat As Int32, ByRef pBuffer As System.Byte, ByVal nbMax As Int32) As Int32
    End Function
    ' A combination of DIB_WriteArrayToFilename and DIB_WriteToBuffer.
    ' Writes n images to a memory buffer in the specified format.
    ' See DIB_WriteToBuffer above for the meaning of pBuffer and nbMax.
    ' Return value: See DIB_WriteToBuffer above.



    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ToDibSection(ByVal hdib As IntPtr) As IntPtr
    End Function
    ' Converts the given DIB into a kind of bitmap called a DibSection.
    ' *** IMPORTANT: The input DIB is consumed and becomes invalid ***
    ' A DibSection is a special kind of HBITMAP.  Many languages
    ' and imaging classes (such as GDI+, .NET Image, Delphi TBitmap) do
    ' not easily accept DIBs but readily accept a DibSection/HBITMAP.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_FromBitmap(ByVal hbm As IntPtr, ByVal hdc As IntPtr) As IntPtr
    End Function
    ' Create a DIB with the contents of a GDI bitmap (preferably a DibSection).
    ' >> The input bitmap is NOT deleted - the returned DIB is a copy.
    ' If hdc = 0 (NULL) a default HDC is used.
    ' See also: DIB_ToDibSection

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_IsBlank(ByVal hdib As IntPtr, ByVal dDarkness As Double) As Boolean
    End Function
    ' Return TRUE(1) if the DIB has less than dDarkness fraction of 'dark' pixels.
    ' Return FALSE(0) otherwise.
    ' A typical value of dDarkness would be 0.02 which means 2% dark pixels.
    ' A page with less than 2% dark pixels is probably blank.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Darkness(ByVal hdibFull As IntPtr) As Double
    End Function
    ' Returns the fraction of an image that consists of 'dark' pixels.
    ' These are pixels that would be black, if the image was converted
    ' to B&W using a smart thresholding.  See DIB_SmartThreshold.
    ' Used by DIB_IsBlank to decide if an image is blank.
    ' A return of 0.0 means none, 1.0 means all.  A typical office
    ' document is 0.02 (2%) to 0.32 (32%) dark pixels.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub DIB_GetHistogram(ByVal hdib As IntPtr, ByVal nComponent As Int32, ByVal histo As Int32())
    End Sub
    ' Count the number of occurences of each value of the specified component
    ' in the given DIB (see component codes below).  Put the counts
    ' of each value (0..255) into the histo array.
    ' The histo array *must* be an array of 256 32-bit integers.
    ' Only works on B&W, grayscale, palette, and 24-bit RGB images.
    ' Example: If hdib contains 237 pixels with a grayscale value of 17, then
    ' this call will return histo[17] = 237.  Components are normalized
    ' into the range 0..255.
    ' Note: If hdib is a 1-bit B&W image, then histo will be all 0's, except
    ' for hist[0] (black) and hist[255] (white).
    '
    ' Component codes:
    Friend Const COMPONENT_GRAY As Int32 = 0
    Friend Const COMPONENT_RED As Int32 = 1
    Friend Const COMPONENT_GREEN As Int32 = 2
    Friend Const COMPONENT_BLUE As Int32 = 3
    Friend Const COMPONENT_LUMINANCE As Int32 = 0
    Friend Const COMPONENT_SAT As Int32 = 4
    Friend Const COMPONENT_HUE As Int32 = 5

    ' For gray and B&W images, R, G, and B components are equal, and Hue and Sat are 0.
    ' Other components available upon request: support@dosadi.com


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ComponentCopy(ByVal hdib As IntPtr, ByVal nComponent As Int32) As IntPtr
    End Function
    ' Extract and return one component (channel) of the given image.
    ' The returned image is an 8-bit grayscale image containing the
    ' specified channel of the input image, with the same width,
    ' height, and DPI.
    ' 
    ' Note: In future this function may return a 16-bit deep image
    ' when given a 16 bit/channel input image.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Avg(ByVal hdib As IntPtr, ByVal nComp As Int32) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_AvgRegion(ByVal hdib As IntPtr, ByVal nComp As Int32, ByVal leftx As Int32, ByVal topy As Int32, ByVal w As Int32, ByVal h As Int32) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_AvgRow(ByVal hdib As IntPtr, ByVal nComp As Int32, ByVal rowy As Int32) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_AvgColumn(ByVal hdib As IntPtr, ByVal nComp As Int32, ByVal colx As Int32) As Double
    End Function
    ' Average the values of pixels in an image, region, row or column.
    ' Note that row 0 is the visually top-most row of an image.
    ' Averages either intensity (brightness) or individual color channels,
    ' or saturation.
    ' See component codes above, for DIB_GetHistogram.
    ' Regardless of image format, white = 255.0 and black = 0, even
    ' for 1-bit B&W or 16-bit grayscale or color images.
    ' DOES NOT SUPPORT: 4-bit/pixel images, CMY(K) images.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ProjectRows(ByVal hdib As IntPtr, ByVal nComp As Int32) As IntPtr
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ProjectColumns(ByVal hdib As IntPtr, ByVal leftx As Int32, ByVal topy As Int32, ByVal w As Int32, ByVal h As Int32, ByVal nComp As Int32) As IntPtr
    End Function
    ' These functions create and return a 1 row x N column image, containing
    ' the average value of the rows (columns) of the input image, in the
    ' specified channel (component).
    ' If the source image is <= 8-bit/sample, the result image is 8-bit/sample.
    ' If the source image is 16 bit/sample, so is the result image.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_Posterize(ByVal hdib As IntPtr, ByVal nLevels As Int32) As Int32
    End Function


    '--- EXPERIMENTAL: The following functions may be removed or changed at any time.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_ForwardDCT(ByVal hdib As IntPtr) As IntPtr
    End Function

    '--- OBSOLETE: The following functions are for backward compatibility only:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_WriteNativeToFilename")> _
    Public Shared Function WriteNativeToFilename(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_LoadNativeFromFilename")> _
    Public Shared Function LoadNativeFromFilename(ByVal sFileName As String) As IntPtr
    End Function
    'HDIB EZTAPI TWAIN_LoadNativeFromFile(HFILE fh);
    ' removed - contact Dosadi if this causes problems for you.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_NegotiateXferCount")> _
    Public Shared Function NegotiateXferCount(ByVal nXfers As Int32) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DibDepth")> _
    Public Shared Function DibDepth(ByVal hdib As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DibWidth")> _
    Public Shared Function DibWidth(ByVal hdib As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DibHeight")> _
    Public Shared Function DibHeight(ByVal hdib As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DibNumColors")> _
    Public Shared Function DibNumColors(ByVal hdib As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DibRowBytes")> _
    Public Shared Function DibRowBytes(ByVal hdib As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DibReadRow")> _
    Public Shared Sub DibReadRow(ByVal hdib As IntPtr, ByVal nRow As Int32, ByRef prow As System.Byte)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_CreateDibPalette")> _
    Public Shared Function CreateDibPalette(ByVal hdib As IntPtr) As IntPtr
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DrawDibToDC")> _
    Public Shared Sub DrawDibToDC(ByVal hDC As IntPtr, ByVal dx As Int32, ByVal dy As Int32, ByVal w As Int32, ByVal h As Int32, ByVal hdib As IntPtr, ByVal sx As Int32, ByVal sy As Int32)
    End Sub

    '--------- File Read/Write

    '---- File Formats
    Friend Const TWFF_TIFF As Int32 = 0
    Friend Const TWFF_BMP As Int32 = 2
    Friend Const TWFF_JFIF As Int32 = 4
    Friend Const TWFF_PNG As Int32 = 7
    Friend Const TWFF_DCX As Int32 = 97
    Friend Const TWFF_GIF As Int32 = 98
    Friend Const TWFF_PDF As Int32 = 99
    ' PDF & GIF support is only provided by EZTwain.
    ' Note: BMP support is built into EZTwain, so is always available.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsJpegAvailable")> _
    Public Shared Function IsJpegAvailable() As Boolean
    End Function
    ' Return TRUE (1) if JPEG/JFIF image files can be read and written.
    ' Returns 0 if JPEG support has not been installed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsPngAvailable")> _
    Public Shared Function IsPngAvailable() As Boolean
    End Function
    ' Return TRUE (1) if PNG format support is available.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsTiffAvailable")> _
    Public Shared Function IsTiffAvailable() As Boolean
    End Function
    ' Return TRUE (1) if TIFF format support is available.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsPdfAvailable")> _
    Public Shared Function IsPdfAvailable() As Boolean
    End Function
    ' Return TRUE (1) if PDF format support is available.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsGifAvailable")> _
    Public Shared Function IsGifAvailable() As Boolean
    End Function
    ' Return TRUE (1) if GIF format support is available.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsDcxAvailable")> _
    Public Shared Function IsDcxAvailable() As Boolean
    End Function
    ' Return TRUE (1) if DCX format support is available.
    ' Note that DCX files can only hold 1-bit
    ' B&W images - EZTwain converts the image data as needed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsFormatAvailable")> _
    Public Shared Function IsFormatAvailable(ByVal nFF As Int32) As Boolean
    End Function
    ' Return TRUE (1) if the specified file format support
    ' is available for writing and possibly reading files.
    ' A format is considered available if EZTwain can load
    ' the necessary DLLs.  See the 

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_FormatVersion")> _
    Public Shared Function FormatVersion(ByVal nFF As Int32) As Int32
    End Function
    ' Return the format module version * 100.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsFileExtensionAvailable")> _
    Public Shared Function IsFileExtensionAvailable(ByVal sExt As String) As Boolean
    End Function
    ' Return TRUE (1) if the file format corresponding to the given
    ' file extension ("TIF", ".gif", "jpeg", etc.) is available.
    ' Case does not matter, leading '.' is optional.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_FormatFromExtension")> _
    Public Shared Function FormatFromExtension(ByVal sExt As String, ByVal nFF As Int32) As Int32
    End Function
    ' Return the file-format code (see File Formats above) for
    ' the given extension.  If pzExt is unrecognized, returns nFF.
    ' Case does not matter, leading '.' is optional.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ExtensionFromFormat")> _
    Public Shared Function ExtensionFromFormatPtr(ByVal nFF As Int32, ByVal sDefExt As String) As IntPtr
    End Function
    Public Shared Function ExtensionFromFormat(ByVal nFF As Int32, ByVal sDefExt As String) As String
        ExtensionFromFormat = Marshal.PtrToStringAnsi(ExtensionFromFormatPtr(nFF, sDefExt))
    End Function
    ' Return the default extension associated with a file format.(See File Formats above.)
    ' Note: The leading '.' is included e.g. ".bmp", ".tif", etc.
    ' If nFF is not a valid value, returns its second parameter.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetExtensionFromFormat")> _
    Public Shared Sub GetExtensionFromFormat(ByVal nFF As Int32, ByVal sDefExt As String, ByVal szExtension As System.Text.StringBuilder)
    End Sub
    ' Return the default extension for the given file-format code, in the 3rd parameter.
    ' The caller is responsible for allocating a string of at least 5 characters for the 3rd parameter.
    ' If the file format is not recognized, returns the value of the 2nd parameter.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetSaveFormat")> _
    Public Shared Function SetSaveFormat(ByVal nFF As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetSaveFormat")> _
    Public Shared Function GetSaveFormat() As Int32
    End Function
    ' Select the default file format for DIB_WriteToFilename
    ' and TWAIN_WriteToFilename to use, when they do not
    ' recognize the file extension.
    ' Displays a warning message if the format is not available.
    ' Returns TRUE (1) if ok, FALSE (0) if format is invalid or not available.
    ' See list of file formats above.  Some formats are not supported
    ' by some versions of EZTWAIN, or require external DLLs be installed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetJpegQuality")> _
    Public Shared Sub SetJpegQuality(ByVal nQ As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetJpegQuality")> _
    Public Shared Function GetJpegQuality() As Int32
    End Function
    ' Set the 'quality' of subsequently saved JPEG/JFIF image files.
    ' nQ = 100 is maximum quality & minimum compression.
    ' nQ = 75 is 'good' quality, the default.
    ' nQ = 1 is minimum quality & maximum compression.

    '- Special TIFF options ------------------------------------------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffStripSize")> _
    Public Shared Sub SetTiffStripSize(ByVal nBytes As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetTiffStripSize")> _
    Public Shared Function GetTiffStripSize() As Int32
    End Function
    ' Set/Get the size of the 'strips' that TIFF files are divided into.
    ' Some (bogus) TIFF readers cannot handle multiple strips, to make
    ' them happy set the strip size to -1.
    ' Default value = 32768 (subject to change, in theory.)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffImageDescription")> _
    Public Shared Function SetTiffImageDescription(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffDocumentName")> _
    Public Shared Function SetTiffDocumentName(ByVal sText As String) As Boolean
    End Function
    ' Set the TIFF ImageDescription or DocumentName tags for output.
    ' These values apply only to the next TIFF file written, and are cleared
    ' once the file is closed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffCompression")> _
    Public Shared Function SetTiffCompression(ByVal nPT As Int32, ByVal nComp As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetTiffCompression")> _
    Public Shared Function GetTiffCompression(ByVal nPT As Int32) As Int32
    End Function
    ' Set/Get the compression mode to use when writing TIFF files.
    ' Set returns TRUE (1) if successful, FALSE (0) otherwise.
    ' nPT specifies the Pixel Type - See the TWPT_* constants.
    ' Different compressions apply to different pixel types - see below.
    ' Using nPT=-1 means 'for all applicable pixel types.'
    ' nComp specifies the compression, here are the codes:
    Friend Const TIFF_COMP_NONE As Int32 = 1
    Friend Const TIFF_COMP_CCITTRLE As Int32 = 2
    Friend Const TIFF_COMP_CCITTFAX3 As Int32 = 3
    Friend Const TIFF_COMP_CCITTFAX4 As Int32 = 4
    Friend Const TIFF_COMP_LZW As Int32 = 5
    Friend Const TIFF_COMP_JPEG As Int32 = 7
    Friend Const TIFF_COMP_PACKBITS As Int32 = 32773

    ' Default for BW is TIFF_COMP_CCITTFAX4
    ' Default for all other pixel types is TIFF_COMP_NONE.

    ' Setting TIFF tags explicitly, including custom/private tags:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffTagShort")> _
    Public Shared Function SetTiffTagShort(ByVal nTagId As Int32, ByVal sValue As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffTagLong")> _
    Public Shared Function SetTiffTagLong(ByVal nTagId As Int32, ByVal nValue As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffTagString")> _
    Public Shared Function SetTiffTagString(ByVal nTagId As Int32, ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffTagDouble")> _
    Public Shared Function SetTiffTagDouble(ByVal nTagId As Int32, ByVal dValue As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffTagRational")> _
    Public Shared Function SetTiffTagRational(ByVal nTagId As Int32, ByVal dValue As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffTagRationalArray")> _
    Public Shared Function SetTiffTagRationalArray(ByVal nTagId As Int32, ByVal dValues As Double(), ByVal n As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffTagBytes")> _
    Public Shared Function SetTiffTagBytes(ByVal nTagId As Int32, ByRef pdata As System.Byte, ByVal nBytes As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiffTagUndefined")> _
    Public Shared Function SetTiffTagUndefined(ByVal nTagId As Int32, ByRef pdata As System.Byte, ByVal nBytes As Int32) As Boolean
    End Function
    ' Note: It works to use SetTiffTagDouble to set standard TIFF tags that are of
    ' type RATIONAL, but we recommend using SetTiffTagRational.
    ' If you have trouble setting a custom private tag, it may help to
    ' define it to EZTwain - see TWAIN_DefineCustomTiffTag, below.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ResetTiffTags")> _
    Public Shared Sub ResetTiffTags()
    End Sub
    ' The functions above allow specific TIFF tags to be set.
    ' Whatever value(s) you set will be used in *each image written to TIFF*
    ' until you call TWAIN_ResetTiffTags.
    ' Note that integer values are appropriately converted to 16- or 32-bit
    ' signed or unsigned as needed by the specific tag.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetTiffTagAscii")> _
    Public Shared Function GetTiffTagAscii(ByVal sFilename As String, ByVal nPage As Int32, ByVal nTag As Int32, ByVal nLen As Int32, ByVal buffer As System.Text.StringBuilder) As Boolean
    End Function
    ' Read the value of the specified tag from the given page of the given TIFF file,
    ' copying the string into buffer, which has room for len characters.
    ' Returns True(1) if successful, False(0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_TiffTagAscii")> _
    Public Shared Function TiffTagAsciiPtr(ByVal sFilename As String, ByVal nPage As Int32, ByVal nTag As Int32) As IntPtr
    End Function
    Public Shared Function TiffTagAscii(ByVal sFilename As String, ByVal nPage As Int32, ByVal nTag As Int32) As String
        TiffTagAscii = Marshal.PtrToStringAnsi(TiffTagAsciiPtr(sFilename, nPage, nTag))
    End Function
    ' Return the value of the specified tag from the given page of the given TIFF file,
    ' as a human-readable string.
    ' Numeric values are converted to decimal numeric representation.
    ' In case of failure, it returns the empty string.
    ' In case of error, call TWAIN_ReportLastError to display details,
    ' or call TWAIN_LastErrorCode and related functions.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetFileAppendFlag")> _
    Public Shared Sub SetFileAppendFlag(ByVal bAppend As Boolean)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetFileAppendFlag")> _
    Public Shared Function GetFileAppendFlag() As Boolean
    End Function
    ' Set or get the File Append Flag.
    ' When this flag is non-zero and EZTwain writes to an existing TIFF, PDF or DCX
    ' file, the new images are *appended* to the existing file.
    ' When this flag is False (0), writing to any existing file replaces the file.
    '
    ' The default state of this flag is: False (0).
    '
    ' Note: Only TIFF, PDF, and DCX formats are affected.
    ' This applies to all functions that write images, primarily:
    '  TWAIN_AcquireToFilename, TWAIN_AcquireMultipageFile,
    '  DIB_WriteToFilename, TWAIN_BeginMultipageFile, etc.

    '- PDF Specific ------------------------------------------

    ' These functions configure or add information to the next output PDF file:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPdfTitle")> _
    Public Shared Function SetPdfTitle(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPdfAuthor")> _
    Public Shared Function SetPdfAuthor(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPdfSubject")> _
    Public Shared Function SetPdfSubject(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPdfKeywords")> _
    Public Shared Function SetPdfKeywords(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPdfCreator")> _
    Public Shared Function SetPdfCreator(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPdfProducer")> _
    Public Shared Function SetPdfProducer(ByVal sText As String) As Boolean
    End Function

    ' Writing metadata into PDF:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SetTitle(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SetAuthor(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SetSubject(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SetKeywords(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SetCreator(ByVal sText As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SetProducer(ByVal sText As String) As Boolean
    End Function

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SetCompression(ByVal nPT As Int32, ByVal nComp As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_GetCompression(ByVal nPT As Int32) As Int32
    End Function
    ' Select the compression algorithm to use for images with the given pixel format.
    ' See the TWPT_* constants for the various pixel formats.
    ' Note that a pixel format of -1 means 'all applicable formats'.
    ' Available values of nComp are:
    Friend Const COMPRESSION_DEFAULT As Int32 = -1
    Friend Const COMPRESSION_NONE As Int32 = 1
    Friend Const COMPRESSION_FLATE As Int32 = 5
    Friend Const COMPRESSION_JPEG As Int32 = 7

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SelectPageSize(ByVal nPaper As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SelectedPageSize() As Int32
    End Function
    ' Set/Get the standard page-size for subsequent PDF output pages.
    ' The values are PAPER_ values defined elsewhere
    ' in this file, search for PAPER_A4 etc.
    ' EZTwain initializes this to PAPER_NONE (0).
    ' With PAPER_NONE selected, EZTwain writes each output image into a
    ' page the same size as the image.  Setting a page size tells
    ' EZTwain to center each output image within a page of the
    ' specified size, shrinking larger images to fit.
    ' Calling PDF_SelectPageSize(PAPER_NONE) clears the page-size
    ' back to the default i.e. 'no specific size'.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub PDF_SetOpenPassword(ByVal sPassword As String)
    End Sub
    ' Set the password to be used to open subsequent PDF files.
    ' This password is used until reset to the empty string.
    ' If you have set an OpenPassword, the user will not be prompted
    ' for a password when an encrypted PDF is opened for reading.

    ' To suppress prompting by EZTwain, use this function to set
    ' an extremely unlikely password string, such as " " or "\t".

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_SetPDFACompliance(ByVal nLevel As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_GetPDFACompliance() As Int32
    End Function
    ' Set/Get the PDF/A Compliance level.
    ' Level 0 is 'no particular compliance'. (*default*)
    ' Level 1 is PDF/A-1(b) - the PDF/A Part 1 level suitable for
    ' scanned documents.
    ' No other nLevel values are accepted at this time.
    ' When PDFA compliance is set to 1, PDF output is made to comply with
    ' ISO 19005-1 PDF/A-1.  For the most part this is invisible, but certain
    ' PDF settings and operations become illegal, and there are optional
    ' function calls that make your PDF's "more" PDF/A compliant.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub PDF_SetUserPassword(ByVal sPassword As String)
    End Sub
    ' Define a user password for the next/current output PDF file.
    ' This turns on encryption for the file.
    ' When a PDF file is completed and closed, the user password is cleared.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub PDF_SetOwnerPassword(ByVal sPassword As String)
    End Sub
    ' Define an owner password for the next/current output PDF file.
    ' This turns on encryption for the file.
    ' When a PDF file is completed and closed, the user password is cleared.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub PDF_SetPermissions(ByVal nPermission As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_GetPermissions() As Int32
    End Function
    ' Set or Get the permissions mask to be written into the next/current
    ' output PDF file. This mask specifies operations to be allowed or
    ' prevented on the file - see the PDF_PERMIT constants.
    '
    ' Important Notes
    '
    ' * Permissions are only written if you set a User or Owner password.
    ' * Acrobat honors these restrictions, but other PDF readers may not.
    ' * Any permissions you set only apply to the next PDF file you write.
    ' * The default permissions mask is 'allow everything' (-1)
    ' * Setting permissions=0 means 'prevent everything'
    '
    ' You can use bitwise operations, or +/- to combine these constants.
    ' For example, to disallow copying text and graphics from the file:
    '    PDF_SetPermissions(PDF_PERMIT_ALL - PDF_PERMIT_COPY)
    '
    '      named constant                   value   if restricted, Acrobat will prevent:
    Friend Const PDF_PERMIT_PRINT As Int32 = 4
    Friend Const PDF_PERMIT_MODIFY As Int32 = 8
    Friend Const PDF_PERMIT_COPY As Int32 = 16
    Friend Const PDF_PERMIT_ANNOTS As Int32 = 32
    ' You can also use this nPermission value, by itself:
    Friend Const PDF_PERMIT_ALL As Int32 = -1


    '-- Writing text into PDF. ------------------------
    '
    ' The following functions apply to the next PDF file or page that is output,
    ' so you make them *before* you write the PDF page they apply to.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub PDF_DrawText(ByVal leftx As Double, ByVal topy As Double, ByVal sText As String)
    End Sub
    ' Draw text into the next PDF page, x pixels from the left edge
    ' and y pixels down from the top of the page.
    ' Note 1: This is not 'native' PDF coordinates, which are
    ' usually in points, from the lower-left corner of the page.
    ' Note 2: This call only makes sense if followed at some point
    ' by a call that writes an image to PDF.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub PDF_DrawInvisibleText(ByVal leftx As Double, ByVal topy As Double, ByVal sText As String)
    End Sub
    ' Like PDF_DrawText, but text is drawn in invisible mode.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub PDF_SetTextVisible(ByVal bVisible As Boolean)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_GetTextVisible() As Boolean
    End Function
    ' Set the visibility of the text written by subsequent PDF_DrawText
    ' calls. A parameter of True (non-0) means make text visible, a parameter
    ' of False (0) means make text invisible.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub PDF_SetTextSize(ByVal dfs As Double)
    End Sub
    ' Set the size of the current font, for subsequent PDF_DrawText calls.
    ' Normally this is a traditional size in points, like 10.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub PDF_SetTextHorizontalScaling(ByVal dhs As Double)
    End Sub

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function PDF_WriteOcrText(ByVal text As String, ByVal ax As Int32(), ByVal ay As Int32(), ByVal aw As Int32(), ByVal ah As Int32(), ByVal xdpi As Double, ByVal ydpi As Double) As Boolean
    End Function
    ' Write previously OCR'd text to the next PDF output page.
    ' ---parameters---
    ' text is the text, of course - as returned by OCR_Text.
    ' ax and ay are arrays of x,y positions of the characters in text - as returned
    ' by OCR_GetCharPositions.  These are pixel coordinates relative to the top-left of the page.
    ' aw and ah are arrays of (width,height) information as returned by OCR_GetCharSizes.
    ' xdpi and ydpi are the resolution values (DPI) of the source image, required to map the text
    ' size from pixels into PDF font sizes.  The resolution can be obtained from the image
    ' using DIB_XResolution and DIB_YResolution, or you can call OCR_GetResolution at the
    ' same time you call OCR_GetCharPositions and OCR_GetCharSizes.

    '---------------------------------------------------------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_WriteToFilename")> _
    Public Shared Function WriteToFilename(ByVal hdib As IntPtr, ByVal sFileName As String) As Int32
    End Function
    ' Writes the specified image to a file.
    ' This is the same as DIB_WriteToFilename - please refer to that function.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_LoadFromFilename")> _
    Public Shared Function LoadFromFilename(ByVal sFileName As String) As IntPtr
    End Function
    ' Load a .BMP file, or any other available format.
    ' Accepts a filename (including path & extension).
    ' If the filename is NULL or points to a null string, the user is
    ' prompted to choose a file with a standard File Open dialog.
    ' Returns a DIB handle if successful, otherwise NULL.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_LoadPage")> _
    Public Shared Function LoadPage(ByVal sFileName As String, ByVal nPage As Int32) As IntPtr
    End Function
    ' Short for DIB_SelectPageToLoad, DIB_LoadFromFilename.
    ' Load the specified page from the specified file.
    ' Page 0 is the first page in a file.  Multiple
    ' pages are only supported in TIFF, PDF and DCX files, all other file
    ' formats have a single page, page #0.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_FormatOfFile")> _
    Public Shared Function FormatOfFile(ByVal sFileName As String) As Int32
    End Function
    ' Return the format of the specified file.
    ' See the TWFF_* codes elsewhere in this file.
    ' A return value < 0 means 'unrecognized format'.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_PagesInFile")> _
    Public Shared Function PagesInFile(ByVal sFileName As String) As Int32
    End Function
    ' Return the number of pages in the specified file.
    ' For multipage formats (TIFF, PDF, DCX), the pages are counted.
    ' All other recognized formats return a page count of 1.
    ' If the file cannot be opened, read, recognized, etc.
    ' this function records an error and returns -1.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_PromptForOpenFilename")> _
    Public Shared Function PromptForOpenFilename(ByVal sFileName As System.Text.StringBuilder) As Boolean
    End Function
    ' Prompt the user for a file to open.
    ' Returns TRUE(1) if user selected a file, FALSE(0) if user cancelled.
    ' If it returns TRUE, the fully-qualified filepath & name is returned
    ' in the buffer referenced by the parameter.
    ' The caller is responsible for allocating (and deallocating) the
    ' buffer of at least 260 characters.
    ' The file dialog has a file-type list, which is loaded based
    ' on the formats that are currently supported for loading.
    ' The default file-type is "any supported format".

    '--------- File View Dialog

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ViewFile")> _
    Public Shared Function ViewFile(ByVal sFileName As String) As Int32
    End Function
    ' Display the specified file in a viewer window that allows the
    ' user to browse to all pages (if more than one).
    ' If the file name is NULL or the null string, the user is prompted
    ' with a standard file-open dialog, offering all the filetypes that
    ' EZTwain believes it can open.
    ' The default dialog has an OK button only.
    ' Return values:
    '  1   [OK] button pressed (in modal dialog)
    '  1   File displayed - in case of modeless dialog.
    '  0   [Cancel] button pressed
    ' -1   user cancelled file-open prompt (if you supplied a null filename)
    ' -2   error displaying dialog, opening file, etc.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetViewOption")> _
    Public Shared Function SetViewOption(ByVal sOption As String, ByVal sValue As String) As Boolean
    End Function
    ' Set various options and parameters for the viewer window.
    ' See TWAIN_ViewFile above.
    '
    ' option                        form    meaning
    ' title                 string  the title (caption) of the viewer window
    ' left                          x|x%    left(x) coordinate of window, in pixels or as a percent of screen.
    ' top                           y|y%    top coordinate of window
    ' bottom                        y|y%
    ' right                 x|x%
    ' width                 w|w%    width of viewer window, in pixels or as a percent of screen.
    ' height                        h|h%
    ' size                          w,h             width and height together, pixels or percentages
    ' topleft                       x,y             x and y together, pixels or percentages
    ' position                      x,y,w,h left,top,width,height - in pixels or percentages
    ' pos                                   same as position
    ' pos.remember          bool    if true, remember viewer position between showings. Default: false.
    ' timeout                       n               in seconds. Currently ignored.
    ' visible                       bool    if viewer is open, show or hide it.  Default: true
    ' ok.visible            bool    if true, include an [OK] button in the viewer. Default: true.
    ' cancel.visible        bool    if true, include a [Cancel] button. Default: false
    ' print.visible bool    if true, include a [Print] button. Default: false.
    ' modeless                      bool    if true, leave viewer open until TWAIN_ViewClose. Default: false.
    ' modal                 bool    opposite of modeless.
    ' reset                 ...             setting this option resets all options to default value.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsViewOpen")> _
    Public Shared Function IsViewOpen() As Boolean
    End Function
    ' Return True if the viewer window is open, False otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ViewClose")> _
    Public Shared Function ViewClose() As Boolean
    End Function
    ' If the viewer window is open (as a modeless dialog), close it.
    ' The viewer window is normally modal, but can be made modeless
    ' with TWAIN_SetViewOption("modeless", "true")
    ' No effect if no viewer window is open.
    ' Returns True(1) if it closed the viewer window, False(0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetLastViewPosition")> _
    Public Shared Function GetLastViewPosition(ByRef pleft As Int32, ByRef ptop As Int32, ByRef pwidth As Int32, ByRef pheight As Int32) As Boolean
    End Function
    ' Return the screen coordinates, in pixels, of the last known position of the
    ' viewer window (the dialog displayed by TWAIN_ViewFile and DIB_View functions.)
    ' The four parameters are pointers to 32-bit integers or if your language
    ' prefers, four 32-bit integers passed by reference.
    ' The four returned values are the left edge, the top edge (counting down from screen top)
    ' the width, and the height of the View window, the last time it was closed or resized.
    '
    ' This function can be used in conjunction with TWAIN_SetViewOption("position","x,y,w,h") to
    ' remember and restore the view window position.

    '--------- Multipage File Output

    Friend Const MULTIPAGE_TIFF As Int32 = 0
    Friend Const MULTIPAGE_PDF As Int32 = 1
    Friend Const MULTIPAGE_DCX As Int32 = 2

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetMultipageFormat")> _
    Public Shared Function SetMultipageFormat(ByVal nFF As Int32) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetMultipageFormat")> _
    Public Shared Function GetMultipageFormat() As Int32
    End Function
    ' Select/query the default multipage file save format.
    ' The default when EZTwain is loaded is MULTIPAGE_TIFF.
    ' Note that if you use a recognized extension in the name
    ' of your multipage file - such as .tif, .pdf or .dcx, then
    ' the file will be written in that format.  The file
    ' extension overrides SetMultipageFormat.
    '
    ' SetMultipageFormat returns:
    '  0 = success,
    ' -1 = invalid/unrecognized format
    ' -3 = format is currently unavailable (missing/bad DLL)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetLazyWriting")> _
    Public Shared Sub SetLazyWriting(ByVal bYes As Boolean)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetLazyWriting")> _
    Public Shared Function GetLazyWriting() As Boolean
    End Function
    ' Get/Query the value of the 'LazyWriting' flag.
    ' NOTE: The default value of this flag is: TRUE.
    ' When the LazyWriting flag is set (TRUE), multipage files
    ' are written by a background thread, allowing your
    ' program to continue executing (scanning for example).
    ' Only when EndMultipageFile is called does the program
    ' wait until all the pages of the file have actually
    ' been written to disk.
    ' This also applies to AcquireMultipageFile, which internally
    ' uses these multipage output functions.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function DIB_WriteArrayToFilename(ByVal ahdib As IntPtr(), ByVal n As Int32, ByVal sFileName As String) As Int32
    End Function
    ' Write n images from array ahdib to the specified file.
    ' If n is 1, this is exactly equivalent to calling DIB_WriteToFilename.
    ' If n > 1, this is a shortcut for calling
    '    TWAIN_BeginMultipageFile,
    '      TWAIN_DibWritePage (for each image)
    '    TWAIN_EndMultipageFile
    ' ...with appropriate error handling, of course.
    '
    ' Return values:
    '        0      success
    '       -1      user cancelled File Save dialog
    '       -2      file open error (invalid path or name, or access denied)
    '       -3      a) image is invalid (null or invalid DIB handle)
    '      b) support for the save format is not available
    '      c) DIB format incompatible with save format e.g. B&W to JPEG.
    '       -4      writing data failed, possibly output device is full
    '  -5  other unspecified internal error
    '  -6  a multipage file is already open
    '  -7  multipage support is not installed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_BeginMultipageFile")> _
    Public Shared Function BeginMultipageFile(ByVal sFileName As String) As Int32
    End Function
    ' Create an empty multipage file of the given name.
    ' If the filename is NULL or points to the null string, the user
    ' is prompted with a standard File Save dialog.
    ' If the filename includes an extension (.tif, .tiff, .mpt, .pdf or .dcx)
    ' then the corresponding format is used for the file.
    ' If you do not supply an extension, the default multipage format is used.

    ' Return values:
    '        0      success
    '       -1      user cancelled File Save dialog
    '       -2      file open error (invalid path or name, or access denied)
    '  -3  file format not available
    '  -5  other unspecified internal error
    '  -6  multipage file already open
    '  -7  Multipage support is not installed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DibWritePage")> _
    Public Shared Function DibWritePage(ByVal hdib As IntPtr) As Int32
    End Function
    '   0   success
    '  -2  internal limit exceeded or insufficient memory
    '  -3  File format is not available (EZxxx DLL not found)
    '  -4  Write error: Output device is full?
    '  -5  invalid/unrecognized file format or 'other' - internal
    '  -6  multipage file not open
    '  -7  Multipage support is not installed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EndMultipageFile")> _
    Public Shared Function EndMultipageFile() As Int32
    End Function
    '   0   success
    '  -3  File format is not available
    '  -4  Write error - drive offline, or ?? (very unlikely)
    '  -5  invalid/unrecognized file format or other internal error
    '  -6  multipage file not open
    '  -7  Multipage support is not installed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_MultipageCount")> _
    Public Shared Function MultipageCount() As Int32
    End Function
    ' Return the number of images (scans) written to the most recently
    ' started multipage file.  In other words, this returns a counter
    ' which is reset by BeginMultipageFile, and is incremented by DibWritePage.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsMultipageFileOpen")> _
    Public Shared Function IsMultipageFileOpen() As Boolean
    End Function
    ' Return True if a multipage output file is open, False otherwise.
    ' Only one multipage output file can be open at a time (per process.)


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_LastOutputFile")> _
    Public Shared Function LastOutputFilePtr() As IntPtr
    End Function
    Public Shared Function LastOutputFile() As String
        LastOutputFile = Marshal.PtrToStringAnsi(LastOutputFilePtr())
    End Function
    ' Return the name of the last file written by EZTwain.
    ' Useful if you pass NULL or the empty string as a filename to
    ' DIB_WriteToFilename or TWAIN_AcquireToFilename, etc.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetOutputPageCount")> _
    Public Shared Sub SetOutputPageCount(ByVal nPages As Int32)
    End Sub
    ' Tell EZTwain how many pages you are about to write to a file.
    ' This is OPTIONAL: The only effect is to add PageNumber tags
    ' to TIFF files.  You can use nPages=0, which means "I don't know".

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_FileCopy")> _
    Public Shared Function FileCopy(ByVal sInFile As String, ByVal sOutFile As String, ByVal nOptions As Int32) As Int32
    End Function
    ' Read all the images or pages from the in file and write them to the out file.
    ' nOptions is currently not used and should be 0.
    ' The formats need not be the same, in fact this function is most often
    ' used to convert for example from TIFF to PDF.  If you specify a single-image
    ' output format (BMP, GIF, PNG, JPG) the input file must have only one page.
    ' Return values:
    '        0      success
    '       -1      user cancelled
    '       -2      file open error (invalid path or name, or access denied)
    '  -3  file format not available or inappropriate (e.g. copying 5-page TIF to JPEG)
    '  -5  other unspecified internal error
    '  -7  Multipage support is not installed.

    '--------- Network file transfer services
    '
    ' These functions require EZCurl.dll to be
    ' in the same folder as Eztwain3.dll

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_IsAvailable() As Boolean
    End Function
    ' TRUE(1) if uploading services are available (= EZCurl.dll can be loaded.)
    ' Returns FALSE(0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_Version() As Int32
    End Function
    ' Return the upload module version * 100.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_MaxFiles() As Int32
    End Function
    ' Return the maximum number of files that can be uploaded in one UPLOAD operation.
    ' i.e. UPLOAD_FilesToURL, UPLOAD_DibsSeparatelyToURL.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_AddFormField(ByVal fieldName As String, ByVal fieldValue As String) As Boolean
    End Function
    ' Set a form field to a value in the next Upload (see below).
    ' The name of the field must be expected by the page/script you upload to.
    ' All fields set with this function are discarded and forgotten after
    ' the next upload that uses them.
    '
    ' For example, suppose you have been uploading scanned documents to your server
    ' using a web form like this:
    ' <form name="form1" method="post" action="http://server.com/newdoc.php" >
    ' <input type="hidden" name="key" value="12345678">
    ' <input type="text" name="vendor id">
    ' <input type="file" name="file">
    ' <input type="submit" name="submit" value="Submit">
    ' </form>
    '
    ' You might automate the upload of a just-scanned image in memory (hdib)
    ' with vendor id = 1290331, with code similar to this:
    '    UPLOAD_AddFormField("key", "12345678")
    '    UPLOAD_AddFormField("vendor id", "1290331")
    '    UPLOAD_DibToURL(hdib, "http://server.com/newdoc.php", "document.pdf", "file")

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_AddHeader(ByVal header As String) As Boolean
    End Function
    ' Add a header line to the next HTTP upload.
    ' You should have some understanding of HTTP protocol to use this!
    ' Don't include any line-break characters.
    ' To send a cookie, use UPLOAD_AddCookie (below).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_AddCookie(ByVal cookie As String) As Boolean
    End Function
    ' Add a cookie line to the next HTTP upload.
    ' Often used to provide session id's e.g.
    '    UPLOAD_AddCookie("ASP.NET_SessionID=" & strSessionID)
    ' or
    '    UPLOAD_AddCookie("JSESSIONID=" & strSessionID)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub UPLOAD_EnableProgressBar(ByVal bEnable As Boolean)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_IsEnabledProgressBar() As Boolean
    End Function
    ' Enable or disable the progress-bar during uploads.
    ' Default state is enabled (TRUE).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_DibToURL(ByVal hdib As IntPtr, ByVal URL As String, ByVal fileName As String, ByVal fieldName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_DibsToURL(ByVal ahdib As IntPtr(), ByVal n As Int32, ByVal URL As String, ByVal fileName As String, ByVal fieldName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_DibsSeparatelyToURL(ByVal ahdib As IntPtr(), ByVal n As Int32, ByVal URL As String, ByVal fileName As String, ByVal fieldName As String) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_FilesToURL(ByVal files As String, ByVal URL As String, ByVal fieldName As String) As Int32
    End Function
    ' Upload an image, set of images, or some files on disk, to a script on a server,
    ' AS IF a form was being submitted via HTTP-POST, with a field or fields of type 'file'.
    '
    ' Important Note - This confuses some people, don't let it happen to you!
    ' Only UPLOAD_FilesToURL looks for actual disk files and uploads them.
    ' All the other UPLOAD functions upload image data, *pretending* it is from a file - no such
    ' file is read, used, or created on the client machine.
    '
    ' UPLOAD_DibsSeparatelyToURL uploads each image as a separate file, appending '1', '2', etc.
    ' to both the filename and the fieldname.  So if you upload n images with fileName="page.jpg"
    ' and fieldName="file", it will upload files as "file1"="page1.jpg", "file2=page2.jpg", etc.
    '
    ' Similarly, UPLOAD_FilesToURL uploads multiple files, appending the counter to the fieldName.
    ' If you specify a fieldName of "file", UPLOAD_FilesToURL will use "file1", "file2", etc.
    ' Note that this applies even if you upload just one file.
    '
    ' hdib      = handle to image to upload.
    ' ahdib     = address or reference to array of hdibs (image handles).
    ' n         = number of images in array ahdib.
    ' fileName  = name of (imaginary) file being uploaded.
    '             Note: the extension on the filename determines the file format.
    ' files     = a string containing one or more filenames, separated by semicolons (;) or vertical bars (|)
    ' URL       = URL to POST the file to, such as http://www.dosadi.com/upload.php
    ' fieldName = name of the form-field. If null or blank, "file" is used.
    '
    ' NOTE: When uploading multiple images as a single file, you must of course
    ' use a file format that supports multiple pages: TIFF, PDF, or DCX.
    '
    ' Return values:
    '    0    success (transaction completed)
    '         Important: A success return (0) means only that the data was sent to the
    '         server and a response was received, not that the receiving script
    '         necessarily accepted the submitted file.  See DIB_UploadResponse below. 
    '   -1     user cancelled File Save dialog (should never happen)
    '   -2     could not write temp file - access denied, volume protected, etc.
    '   -3    a) image is invalid (null or invalid DIB handle)
    '         b) The DLL(s) needed to save that format failed to load
    '         c) DIB format incompatible with save format e.g. uploading a B&W image as JPEG.
    '         d) fileName does not have a recognized extension (.tif, .jpg, .gif, etc)
    '   -4    writing data failed, maybe the disk with the temp folder is full?
    '   -5    other unspecified internal error
    ' -100+n  libcurl returned error code n
    '         for example:
    ' -106    could not resolve host
    ' -107    couldn't connect
    ' -126    could not open/read local file

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub UPLOAD_SetProxy(ByVal hostport As String, ByVal userpwd As String, ByVal bTunnel As Boolean)
    End Sub

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="UPLOAD_Response")> _
    Public Shared Function UPLOAD_ResponsePtr() As IntPtr
    End Function
    Public Shared Function UPLOAD_Response() As String
        UPLOAD_Response = Marshal.PtrToStringAnsi(UPLOAD_ResponsePtr())
    End Function
    ' Return the text received from the server in response to the last upload.
    ' You can check this text to see if the server-script accepted the upload.
    ' There is no predefined limit to the length of the returned string - please
    ' code defensively.  This call is extremely fast, 
    ' (See DIB_PostToURL above.)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function UPLOAD_ResponseLength() As Int32
    End Function
    ' Return the length of the last server response string, as returned
    ' by UPLOAD_Response.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub UPLOAD_GetResponse(ByVal ResponseText As System.Text.StringBuilder)
    End Sub
    ' Retrieve the text received from the server in response to the last upload.
    ' * This text is limited to 1024 characters. *
    ' (See DIB_PostToURL above.)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub UPLOAD_ClearResponse()
    End Sub

    ' Upload callback support

    '--------- Application Registration and Licensing

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetAppTitle")> _
    Public Shared Sub SetAppTitle(ByVal sAppTitle As String)
    End Sub
    ' The short form of Application/Product name registration.
    ' Sets the product name as far as EZTwain and TWAIN are concerned.
    ' This title is used in several ways:
    ' As the title (caption) of any EZTwain dialog boxes / error boxes.
    ' In the progress box of some devices as they transfer images.
    ' In the 'software' field of saved image files in some formats,
    ' including TIFF.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetApplicationKey")> _
    Public Shared Sub SetApplicationKey(ByVal nKey As Int32)
    End Sub
    ' Unlock EZTwain Pro for use with the current application - call this AFTER
    ' calling RegisterApp or SetAppTitle above:  The nKey value must match
    ' the application title (product name) passed to one of those functions.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ApplicationLicense")> _
    Public Shared Sub ApplicationLicense(ByVal sAppTitle As String, ByVal nAppKey As Int32)
    End Sub
    ' Unlock EZTwain using a Single Application License.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetVendorKey")> _
    Public Shared Sub SetVendorKey(ByVal sVendorName As String, ByVal nKey As Int32)
    End Sub
    ' Unlock EZTwain using a Universal Application / Vendor License

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_OrganizationLicense")> _
    Public Shared Sub OrganizationLicense(ByVal sOrganization As String, ByVal nKey As Int32)
    End Sub
    ' Unlock EZTwain using an Organization / In-House Application License.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_RenewTrialLicense")> _
    Public Shared Function RenewTrialLicense(ByVal uKey As Int32) As Boolean
    End Function
    ' Renew or recreate the EZTwain Pro trial license in this computer,
    ' if the Key parameter is a valid trial-renewal key.
    ' Such keys are valid only for some number of days after issue.
    ' Contact Dosadi Support (support@dosadi.com) for such a key.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SingleMachineLicense")> _
    Public Shared Function SingleMachineLicense(ByVal sMsg As String) As Boolean
    End Function
    ' If no valid EZTwain Pro license is found on this computer, prompt
    ' the user with a dialog box asking for a single-machine license key.
    ' If the user supplies a key, try to record & validate it.
    ' Return value:
    ' TRUE if EZTwain Pro is licensed for use on this computer.
    ' (Note this could be because of a trial license, or an organization license).
    ' FALSE if EZTwain Pro is not licensed for use on this computer.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_RegisterApp")> _
    Public Shared Sub RegisterApp(ByVal nMajorNum As Int32, ByVal nMinorNum As Int32, ByVal nLanguage As Int32, ByVal nCountry As Int32, ByVal sVersion As String, ByVal sMfg As String, ByVal sFamily As String, ByVal sAppTitle As String)
    End Sub
    '
    ' TWAIN_RegisterApp can be called *AS THE FIRST CALL*, to register the
    ' application. If this function is not called, the application is given a
    ' 'generic' registration by EZTWAIN.
    ' Registration only provides this information to the Source Manager and any
    ' sources you may open - it is used for debugging, and possibly by some
    ' sources to give special treatment to certain applications.

    '--------- Error Analysis and Reporting ------------------------------------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetResultCode")> _
    Public Shared Function GetResultCode() As Int32
    End Function
    ' Return the result code (TWRC_xxx) from the last triplet sent to TWAIN

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetConditionCode")> _
    Public Shared Function GetConditionCode() As Int32
    End Function
    ' Return the condition code from the last triplet sent to TWAIN.
    ' (To be precise, from the last call to TWAIN_DS below)
    ' If a source is NOT open, return the condition code of the source manager.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_UserClosedSource")> _
    Public Shared Function UserClosedSource() As Boolean
    End Function
    ' Return TRUE (1) if during the last acquire the user asked
    ' the DataSource to close.  0 otherwise of course.
    ' This flag is cleared each time you start any kind of acquire,
    ' and it is set if EZTWAIN receives a
    ' MSG_CLOSEDSREQ message through TWAIN.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ErrorBox")> _
    Public Shared Sub ErrorBox(ByVal sMsg As String)
    End Sub
    ' Post an error message dialog with an OK button.
    ' pzMsg points to a null-terminated message string.
    ' The box caption is the current AppTitle - see SetAppTitle.
    ' If messages are suppressed (see below) this function does nothing.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SuppressErrorMessages")> _
    Public Shared Function SuppressErrorMessages(ByVal bYes As Boolean) As Boolean
    End Function
    ' Enable or disable EZTWAIN error messages to the user.
    ' When bYes = FALSE(0), error messages are displayed.
    ' When bYes = TRUE(non-0), error messages are suppressed.
    ' By default, error messages are displayed.
    ' Returns the previous state of the flag.
    '
    ' EZTWAIN cannot suppress messages from TWAIN or TWAIN device drivers.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ReportLastError")> _
    Public Shared Sub ReportLastError(ByVal msg As String)
    End Sub
    ' If EZTwain has recorded an error and that error has not been
    ' reported to the user, this function displays a modal error dialog
    ' with information about that error.
    ' If msg is non-null and not the empty string, it is included
    ' in the dialog box.
    ' Many EZTwain errors record additional details, and those details
    ' are also inserted in the error dialog.
    '
    ' If the recorded error is EZTEC_NONE (no error) or EZTEC_USER_CANCEL,
    ' no error dialog is displayed.
    ' If the recorded error information indicates that the user cancelled
    ' a TWAIN operation, *or* that the user has already seen an error
    ' message about the error, then no error dialog is displayed.
    '
    ' This function *clears* the recorded error, whether or
    ' not it displays a message, by calling TWAIN_ClearError.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetLastErrorText")> _
    Public Shared Sub GetLastErrorText(ByVal sMsg As System.Text.StringBuilder)
    End Sub
    ' Get a string that describes the last error detected by EZTwain.
    ' Note: This function is called by TWAIN_ReportLastError.
    ' Note: The returned string may contain end-of-line characters.
    ' The parameter is a string variable (char array in C/C++).
    ' You are responsible for allocating room for 512 8-bit characters
    ' in the string variable before calling this function.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_LastErrorText")> _
    Public Shared Function LastErrorTextPtr() As IntPtr
    End Function
    Public Shared Function LastErrorText() As String
        LastErrorText = Marshal.PtrToStringAnsi(LastErrorTextPtr())
    End Function
    ' Return a string that describes the last error detected by EZTwain -
    ' see Notes for TWAIN_GetLastErrorText.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_LastErrorCode")> _
    Public Shared Function LastErrorCode() As Int32
    End Function
    ' Return the last internal EZTWAIN error code. (see EZTEC_ codes below)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ClearError")> _
    Public Shared Sub ClearError()
    End Sub
    ' Set the EZTWAIN internal error code to EZTEC_NONE

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ReportLeaks")> _
    Public Shared Function ReportLeaks() As Boolean
    End Function
    ' Display a message box if EZTwain can detect any memory leaks.
    ' Currently this only counts image handles (DIBs) that have been
    ' allocated but never freed.
    ' Returns True(1) if a problem is detected, False(0) otherwise.

    '//////////////////////////////////////////////////////
    ' EZTwain Error codes
    Friend Const EZTEC_NONE As Int32 = 0
    Friend Const EZTEC_START_TRIPLET_ERRS As Int32 = 1
    Friend Const EZTEC_CAP_GET As Int32 = 2
    Friend Const EZTEC_CAP_SET As Int32 = 3
    Friend Const EZTEC_DSM_FAILURE As Int32 = 4
    Friend Const EZTEC_DS_FAILURE As Int32 = 5
    Friend Const EZTEC_XFER_FAILURE As Int32 = 6
    Friend Const EZTEC_END_TRIPLET_ERRS As Int32 = 7
    Friend Const EZTEC_OPEN_DSM As Int32 = 8
    Friend Const EZTEC_OPEN_DEFAULT_DS As Int32 = 9
    Friend Const EZTEC_NOT_STATE_4 As Int32 = 10
    Friend Const EZTEC_NULL_HCON As Int32 = 11
    Friend Const EZTEC_BAD_HCON As Int32 = 12
    Friend Const EZTEC_BAD_CONTYPE As Int32 = 13
    Friend Const EZTEC_BAD_ITEMTYPE As Int32 = 14
    Friend Const EZTEC_CAP_GET_EMPTY As Int32 = 15
    Friend Const EZTEC_CAP_SET_EMPTY As Int32 = 16
    Friend Const EZTEC_INVALID_HWND As Int32 = 17
    Friend Const EZTEC_PROXY_WINDOW As Int32 = 18
    Friend Const EZTEC_USER_CANCEL As Int32 = 19
    Friend Const EZTEC_RESOLUTION As Int32 = 20
    Friend Const EZTEC_LICENSE As Int32 = 21
    Friend Const EZTEC_JPEG_DLL As Int32 = 22
    Friend Const EZTEC_SOURCE_EXCEPTION As Int32 = 23
    Friend Const EZTEC_LOAD_DSM As Int32 = 24
    Friend Const EZTEC_NO_SUCH_DS As Int32 = 25
    Friend Const EZTEC_OPEN_DS As Int32 = 26
    Friend Const EZTEC_ENABLE_FAILED As Int32 = 27
    Friend Const EZTEC_BAD_MEMXFER As Int32 = 28
    Friend Const EZTEC_JPEG_GRAY_OR_RGB As Int32 = 29
    Friend Const EZTEC_JPEG_BAD_Q As Int32 = 30
    Friend Const EZTEC_BAD_DIB As Int32 = 31
    Friend Const EZTEC_BAD_FILENAME As Int32 = 32
    Friend Const EZTEC_FILE_NOT_FOUND As Int32 = 33
    Friend Const EZTEC_FILE_ACCESS As Int32 = 34
    Friend Const EZTEC_MEMORY As Int32 = 35
    Friend Const EZTEC_JPEG_ERR As Int32 = 36
    Friend Const EZTEC_JPEG_ERR_REPORTED As Int32 = 37
    Friend Const EZTEC_0_PAGES As Int32 = 38
    Friend Const EZTEC_UNK_WRITE_FF As Int32 = 39
    Friend Const EZTEC_NO_TIFF As Int32 = 40
    Friend Const EZTEC_TIFF_ERR As Int32 = 41
    Friend Const EZTEC_PDF_WRITE_ERR As Int32 = 42
    Friend Const EZTEC_NO_PDF As Int32 = 43
    Friend Const EZTEC_GIFCON As Int32 = 44
    Friend Const EZTEC_FILE_READ_ERR As Int32 = 45
    Friend Const EZTEC_BAD_REGION As Int32 = 46
    Friend Const EZTEC_FILE_WRITE As Int32 = 47
    Friend Const EZTEC_NO_DS_OPEN As Int32 = 48
    Friend Const EZTEC_DCXCON As Int32 = 49
    Friend Const EZTEC_NO_BARCODE As Int32 = 50
    Friend Const EZTEC_UNK_READ_FF As Int32 = 51
    Friend Const EZTEC_DIB_FORMAT As Int32 = 52
    Friend Const EZTEC_PRINT_ERR As Int32 = 53
    Friend Const EZTEC_NO_DCX As Int32 = 54
    Friend Const EZTEC_APP_BAD_CON As Int32 = 55
    Friend Const EZTEC_LIC_KEY As Int32 = 56
    Friend Const EZTEC_INVALID_PARAM As Int32 = 57
    Friend Const EZTEC_INTERNAL As Int32 = 58
    Friend Const EZTEC_OUT_SEQ As Int32 = 59
    Friend Const EZTEC_CURL As Int32 = 60
    Friend Const EZTEC_MULTIPAGE_OPEN As Int32 = 61
    Friend Const EZTEC_BAD_SHUTDOWN As Int32 = 62
    Friend Const EZTEC_DLL_VERSION As Int32 = 63
    Friend Const EZTEC_OCR_ERR As Int32 = 64
    Friend Const EZTEC_ONLY_TO_PDF As Int32 = 65
    Friend Const EZTEC_APP_TITLE As Int32 = 66
    Friend Const EZTEC_PATH_CREATE As Int32 = 67
    Friend Const EZTEC_LATE_LIC As Int32 = 68
    Friend Const EZTEC_PDF_PASSWORD As Int32 = 69
    Friend Const EZTEC_PDF_UNSUPPORTED As Int32 = 70
    Friend Const EZTEC_PDF_BAFFLED As Int32 = 71
    Friend Const EZTEC_PDF_INVALID As Int32 = 72
    Friend Const EZTEC_PDF_COMPRESSION As Int32 = 73
    Friend Const EZTEC_NOT_ENOUGH_PAGES As Int32 = 74




    '--------- TWAIN State Control ------------------------------------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Shutdown")> _
    Public Shared Sub Shutdown()
    End Sub
    ' Shuts down and cleans up all EZTwain operations.
    ' All memory allocations are freed, all I/O operations
    ' are completed, any threads are terminated, and
    ' TWAIN is closed and unloaded.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_LoadSourceManager")> _
    Public Shared Function LoadSourceManager() As Boolean
    End Function
    ' Finds and loads the Data Source Manager, TWAIN.DLL.
    ' If Source Manager is already loaded, does nothing and returns TRUE(1).
    ' This can fail if TWAIN.DLL is not installed (in the right place), or
    ' if the library cannot load for some reason (insufficient memory?) or
    ' if TWAIN.DLL has been corrupted.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_OpenSourceManager")> _
    Public Shared Function OpenSourceManager(ByVal hwnd As IntPtr) As Boolean
    End Function
    ' Opens the Data Source Manager, if not already open.
    ' If the Source Manager is already open, does nothing and returns TRUE.
    ' This call will fail if the Source Manager is not loaded.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_OpenDefaultSource")> _
    Public Shared Function OpenDefaultSource() As Boolean
    End Function
    ' This opens the source selected in the Select Source dialog.
    ' If some source is already open, does nothing and returns TRUE.
    ' Will load and open the Source Manager if needed.
    ' If this call returns TRUE, TWAIN is in STATE 4 (TWAIN_SOURCE_OPEN)

    ' These two functions allow you to enumerate the available data sources:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetSourceList")> _
    Public Shared Function GetSourceList() As Boolean
    End Function
    ' Fetches the list of sources into memory, so they can be returned
    ' one by one by TWAIN_GetNextSourceName, below.
    ' Returns TRUE (1) if successful, FALSE (0) otherwise.
    ' Note: In the special (and very unusual) case of an empty list,
    ' this function returns TRUE(1) if there was no other error.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetNextSourceName")> _
    Public Shared Function GetNextSourceName(ByVal sName As System.Text.StringBuilder) As Boolean
    End Function
    ' Copies the next source name in the list into its parameter.
    ' The parameter is a string variable (char array in C/C++).
    ' You are responsible for allocating room for 33 8-bit characters
    ' in the string variable before calling this function.
    ' Returns TRUE (1) if successful, FALSE (0) if there are no more.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_NextSourceName")> _
    Public Shared Function NextSourceNamePtr() As IntPtr
    End Function
    Public Shared Function NextSourceName() As String
        NextSourceName = Marshal.PtrToStringAnsi(NextSourceNamePtr())
    End Function
    ' Returns the next source name in the list.
    ' Returns the empty string when it comes to the end of the list.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetDefaultSourceName")> _
    Public Shared Function GetDefaultSourceName(ByVal sName As System.Text.StringBuilder) As Boolean
    End Function
    ' Copies the name of the TWAIN default source into its parameter.
    ' The parameter is a string variable (char array in C/C++).
    ' You are responsible for allocating room for 33 8-bit characters
    ' in the string variable before calling this function.
    ' Normally returns TRUE (1) but will return FALSE (0) if:
    '   - the TWAIN Source Manager cannot be loaded & initialized or
    '   - there is no current default source (e.g. no sources are installed)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DefaultSourceName")> _
    Public Shared Function DefaultSourceNamePtr() As IntPtr
    End Function
    Public Shared Function DefaultSourceName() As String
        DefaultSourceName = Marshal.PtrToStringAnsi(DefaultSourceNamePtr())
    End Function
    ' Returns the name of the TWAIN default source device, as a string

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_OpenSource")> _
    Public Shared Function OpenSource(ByVal sName As String) As Boolean
    End Function
    ' Opens the source with the given name.
    ' If that source is already open, does nothing and returns TRUE.
    ' If another source is open, closes it and attempts to open the specified source.
    ' Will load and open the Source Manager if needed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EnableSource")> _
    Public Shared Function EnableSource(ByVal hwnd As IntPtr) As Boolean
    End Function
    ' Enables the open Data Source. This posts the source's user interface
    ' and allows image acquisition to begin.  If the source is already enabled,
    ' this call does nothing and returns TRUE.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DisableSource")> _
    Public Shared Function DisableSource() As Boolean
    End Function
    ' Disables the open Data Source, if any.
    ' This closes the source's user interface.
    ' If successful or the source is already disabled, returns TRUE(1).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_CloseSource")> _
    Public Shared Function CloseSource() As Boolean
    End Function
    ' Closes the open Data Source, if any.
    ' If the source is enabled, disables it first.
    ' If successful or source is already closed, returns TRUE(1).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_CloseSourceManager")> _
    Public Shared Function CloseSourceManager(ByVal hwnd As IntPtr) As Boolean
    End Function
    ' Closes the Data Source Manager, if it is open.
    ' If a source is open, disables and closes it as needed.
    ' If successful (or if source manager is already closed) returns TRUE(1).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_UnloadSourceManager")> _
    Public Shared Function UnloadSourceManager() As Boolean
    End Function
    ' Unloads the Data Source Manager i.e. TWAIN.DLL - releasing
    ' any associated memory or resources.
    ' If necessary, it will abort transfers, close the open source
    ' if any, and close the Source Manager.
    ' If successful, it returns TRUE(1)


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsTransferReady")> _
    Public Shared Function IsTransferReady() As Boolean
    End Function

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EndXfer")> _
    Public Shared Function EndXfer() As Boolean
    End Function

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AbortAllPendingXfers")> _
    Public Shared Function AbortAllPendingXfers() As Boolean
    End Function

    '--------- High-level Capability Negotiation Functions --------

    ' These functions should only be called in State 4 (TWAIN_SOURCE_OPEN)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetXferCount")> _
    Public Shared Function SetXferCount(ByVal nXfers As Int32) As Boolean
    End Function
    ' Negotiate with open Source the number of images application will accept.
    ' nXfers = -1 means any number
    ' Returns: TRUE(1) for success, FALSE(0) for failure.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_NegotiatePixelTypes")> _
    Public Shared Function NegotiatePixelTypes(ByVal wPixTypes As Int32) As Boolean
    End Function
    ' Negotiate with the source to restrict pixel types that can be acquired.
    ' This tries to restrict the source to a *set* of pixel types.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.
    ' See TWAIN_AcquireNative for some mask constants.
    ' A parameter of 0 (TWAIN_ANYTYPE) causes no negotiation & no restriction.
    ' You should not assume that the source will honor your restrictions, even
    ' if this call succeeds!

    '----- Unit of Measure
    ' TWAIN unit codes (from twain.h)
    Friend Const TWUN_INCHES As Int32 = 0
    Friend Const TWUN_CENTIMETERS As Int32 = 1
    Friend Const TWUN_PICAS As Int32 = 2
    Friend Const TWUN_POINTS As Int32 = 3
    Friend Const TWUN_TWIPS As Int32 = 4
    Friend Const TWUN_PIXELS As Int32 = 5

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCurrentUnits")> _
    Public Shared Function GetCurrentUnits() As Int32
    End Function
    ' Return the current unit of measure: inches, cm, pixels, etc.
    ' Many TWAIN parameters such as resolution are set and returned
    ' in the current unit of measure.
    ' There is no error return - in case of error it returns 0 (TWUN_INCHES)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetUnits")> _
    Public Shared Function SetUnits(ByVal nUnits As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCurrentUnits")> _
    Public Shared Function SetCurrentUnits(ByVal nUnits As Int32) As Boolean
    End Function
    ' Set the current unit of measure for the source.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.
    ' Common unit codes (TWUN_*) are given above.
    ' Notes:
    ' 1. Most sources do not support all units, some support *only* inches!
    ' 2. If you want to get or set resolution in DPI (dots per *inch*), make
    ' sure the current units are inches, or you might get Dots-Per-cm!
    ' 3. Ditto (same comment) for ImageLayout, see below.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetBitDepth")> _
    Public Shared Function GetBitDepth() As Int32
    End Function
    ' Get the current bitdepth, which can depend on the current PixelType.
    ' Bit depth is per color channel e.g. 24-bit RGB has bit depth 8.
    ' If anything goes wrong, this function returns 0.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetBitDepth")> _
    Public Shared Function SetBitDepth(ByVal nBits As Int32) As Boolean
    End Function
    ' (Try to) set the current bitdepth (for the current pixel type).
    ' Note: You should set a PixelType, then set the bitdepth for that type.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.

    '------- TWAIN Pixel Types (from twain.h)
    Friend Const TWPT_BW As Int32 = 0
    Friend Const TWPT_GRAY As Int32 = 1
    Friend Const TWPT_RGB As Int32 = 2
    Friend Const TWPT_PALETTE As Int32 = 3
    Friend Const TWPT_CMY As Int32 = 4
    Friend Const TWPT_CMYK As Int32 = 5

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetPixelType")> _
    Public Shared Function GetPixelType() As Int32
    End Function
    ' Ask the source for the current pixel type.
    ' If anything goes wrong (it shouldn't), this function returns 0 (TWPT_BW).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPixelType")> _
    Public Shared Function SetPixelType(ByVal nPixType As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCurrentPixelType")> _
    Public Shared Function SetCurrentPixelType(ByVal nPixType As Int32) As Boolean
    End Function
    ' Try to set the current pixel type for acquisition.
    ' The source may select this pixel type, but don't assume it will.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCurrentResolution")> _
    Public Shared Function GetCurrentResolution() As Double
    End Function
    ' Ask the source for the current (horizontal) resolution.
    ' Resolution is in dots per current unit! (See TWAIN_GetCurrentUnits above)
    ' If anything goes wrong (it shouldn't) this function returns 0.0

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetXResolution")> _
    Public Shared Function GetXResolution() As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetYResolution")> _
    Public Shared Function GetYResolution() As Double
    End Function
    ' Returns the current horizontal or vertical resolution, in dots per *current unit*.
    ' In the event of failure, returns 0.0.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetResolution")> _
    Public Shared Function SetResolution(ByVal dRes As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetResolutionInt")> _
    Public Shared Function SetResolutionInt(ByVal nRes As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCurrentResolution")> _
    Public Shared Function SetCurrentResolution(ByVal dRes As Double) As Boolean
    End Function
    ' Try to set the current resolution (in both x & y).
    ' Resolution is in dots per current unit! (See TWAIN_GetCurrentUnits above)
    ' Note: The source may select this resolution, but don't assume it will.

    ' You can also set the resolution in X and Y separately, if your TWAIN
    ' device can handle this:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetXResolution")> _
    Public Shared Function SetXResolution(ByVal dxRes As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetYResolution")> _
    Public Shared Function SetYResolution(ByVal dyRes As Double) As Boolean
    End Function

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetContrast")> _
    Public Shared Function SetContrast(ByVal dCon As Double) As Boolean
    End Function
    ' Try to set the current contrast for acquisition.
    ' The TWAIN standard *says* that the range for this cap is -1000 ... +1000

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetBrightness")> _
    Public Shared Function SetBrightness(ByVal dBri As Double) As Boolean
    End Function
    ' Try to set the current brightness for acquisition.
    ' The TWAIN standard *says* that the range for this cap is -1000 ... +1000

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetThreshold")> _
    Public Shared Function SetThreshold(ByVal dThresh As Double) As Boolean
    End Function
    ' Try to set the threshold for black and white scanning.
    ' Should only affect 1-bit scans i.e. PixelType == TWPT_BW.
    ' The TWAIN default threshold value is 128.
    ' After staring at the TWAIN 1.6 spec for a while, I imagine that it implies
    ' that for 8-bit samples, values >= nThresh are thresholded to 1, others to 0.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCurrentThreshold")> _
    Public Shared Function GetCurrentThreshold() As Double
    End Function
    ' Try to get and return the current value (MSG_GETCURRENT) of the
    ' ICAP_THRESHOLD capability.  If this fails for any reason, it
    ' will return -1.  *VERSIONS BEFORE 2.65 RETURNED 128.0*

    '--------------------------------------------------------------
    ' Automatic post-processing of scanned pages
    '
    '
    ' Automatic deskewing of scanned pages
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetAutoDeskew")> _
    Public Shared Sub SetAutoDeskew(ByVal nMode As Int32)
    End Sub
    ' Select the 'auto-deskew' mode.
    ' Auto-deskew attempts to straighten up scans that are slightly crooked,
    ' up to about 10 degrees.
    ' The currently defined modes are:
    '  0   - no auto deskew (default)
    '  1   - auto deskew using EZTwain software algorithms

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetAutoDeskew")> _
    Public Shared Function GetAutoDeskew() As Int32
    End Function
    ' Return the current AutoDeskew mode.

    '
    ' Automatic discarding of blank pages
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetBlankPageMode")> _
    Public Shared Sub SetBlankPageMode(ByVal nMode As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetBlankPageMode")> _
    Public Shared Function GetBlankPageMode() As Int32
    End Function
    ' Sets or gets the 'Skip Blank Pages' mode.
    ' The currently defined modes are:
    '   0 = no special treatment for blank pages (default)
    '   1 = blank pages are discarded by TWAIN_AcquireMultipageFile.
    ' See TWAIN_SetBlankPageThreshold below for more details.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetBlankPageThreshold")> _
    Public Shared Sub SetBlankPageThreshold(ByVal dDarkness As Double)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetBlankPageThreshold")> _
    Public Shared Function GetBlankPageThreshold() As Double
    End Function
    ' Sets or gets the blank page 'darkness' threshold.
    ' In 'Skip Blank Pages' mode (see above), each page of a multipage
    ' scan is measured for 'darkness'.  If the darkness of a page
    ' is below the BlankPageThreshold, it is considered blank.
    ' See the related functions DIB_IsBlank and DIB_Darkness.
    ' 
    ' The default BlankPageThreshold is 0.02 (= 2% dark pixels).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_BlankDiscardCount")> _
    Public Shared Function BlankDiscardCount() As Int32
    End Function
    ' Return the number of blank pages discarded (skipped) during
    ' the most recent multipage scan.
    ' Of course this only reports pages skipped by software, not
    ' any pages discarded as 'blank' inside the scanner - if such
    ' a feature is enabled.
    '
    ' Automatic cropping of scanned pages
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetAutoCrop")> _
    Public Shared Sub SetAutoCrop(ByVal nMode As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetAutoCrop")> _
    Public Shared Function GetAutoCrop() As Int32
    End Function
    ' Select the AutoCrop mode.
    ' Auto-crop attempts to trim off black areas on the outside
    ' edges of each incoming image during scanning.
    ' It will not be effective on scanners that have white
    ' background outside the scanned document.
    ' The currently defined modes are:
    '  0   - no auto crop (default)
    '  1   - auto crop using EZTwain software algorithms
    '  2   - use scanner autocrop if possible, otherwise no autocrop
    '  3   - use scanner autocrop if possible, otherwise do software autocrop.

    '
    ' Automatic contrast adjustment of scanned pages
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetAutoContrast")> _
    Public Shared Sub SetAutoContrast(ByVal nMode As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetAutoContrast")> _
    Public Shared Function GetAutoContrast() As Int32
    End Function
    ' Select the AutoContrast mode.
    ' Automatically adjust the contrast of each image - see
    ' DIB_AutoContrast for more information.
    ' The currently defined modes are:
    '  0   - no autocontrast.
    '  1   - autocontrast using EZTwain software algorithms

    '
    ' Automatic OCR of scanned pages.
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetAutoOCR")> _
    Public Shared Sub SetAutoOCR(ByVal nMode As Int32)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetAutoOCR")> _
    Public Shared Function GetAutoOCR() As Int32
    End Function
    ' Sets or gets the auto-OCR mode
    ' By default this mode is 0 = OFF.
    ' When this mode is on (1), EZTwain applies OCR, if available, to each incoming
    ' scanned page or image and temporarily stores the result.  In this mode,
    ' if you are scanning directly to PDF format using TWAIN_AcquireToFilename
    ' or TWAIN_AcquireMultipageFile, the OCR'd text is also written to each
    ' PDF page as invisible text, to facilitate indexing and searching.
    ' If you are scanning individual pages you can call OCR_Text or OCR_GetText
    ' to retrieve the text found on the most recently scanned page.
    ' In this mode, any Acquire call discards any previous OCR text.
    '
    ' The currently selected OCR engine is used: See OCR_SelectEngine and co.
    ' Caution: If OCR fails for some reason in auto-OCR mode, an error is recorded
    ' (see TWAIN_LastErrorCode, TWAIN_ReportLastError) but the scanning function
    ' may report success.

    '
    ' Automatic negation of scanned pages
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetAutoNegate")> _
    Public Shared Sub SetAutoNegate(ByVal bYes As Boolean)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetAutoNegate")> _
    Public Shared Function GetAutoNegate() As Boolean
    End Function
    ' Set or get the "AutoNegate" flag: When this flag is set (non-zero)
    ' EZTwain automatically 'negates' any B&W scanned image that is > 80% black
    ' i.e. it exchanges black & white in the image.
    ' This flag is TRUE (1) by default.

    '--------------------------------------------------------------


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetXferMech")> _
    Public Shared Function SetXferMech(ByVal mech As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_XferMech")> _
    Public Shared Function XferMech() As Int32
    End Function
    ' Try to set or get the transfer mode - one of the following:
    Friend Const XFERMECH_NATIVE As Int32 = 0
    Friend Const XFERMECH_FILE As Int32 = 1
    Friend Const XFERMECH_MEMORY As Int32 = 2
    ' You should not need to set this mode directly - using
    ' TWAIN_Acquire, TWAIN_AcquireNative and TWAIN_AcquireFile will set
    ' the appropriate transfer mode for you.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SupportsFileXfer")> _
    Public Shared Function SupportsFileXfer() As Boolean
    End Function
    ' Returns TRUE(1) if the open DS claims to support file transfer mode (XFERMECH_FILE)
    ' Returns FALSE(0) otherwise.
    ' This mode is optional.  If TRUE, you can use AcquireFile.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPaperSize")> _
    Public Shared Function SetPaperSize(ByVal nPaper As Int32) As Boolean
    End Function
    ' During the next scan, request that the scanner scan the specified paper size.
    ' Most scanners support the first few paper sizes, excluding any that are
    ' larger than their physical scan capacity.
    ' To determine the paper sizes supported by a particular scanner, see
    ' "Working with Capabilities" in the EZTwain User Guide.
    '
    ' Note - These are synonyms form the TWSS_* constants in TWAIN.H
    Friend Const PAPER_NONE As Int32 = 0
    Friend Const PAPER_A4LETTER As Int32 = 1
    Friend Const PAPER_A4 As Int32 = 1
    Friend Const PAPER_B5LETTER As Int32 = 2
    Friend Const PAPER_JISB5 As Int32 = 2
    Friend Const PAPER_USLETTER As Int32 = 3
    Friend Const PAPER_USLEGAL As Int32 = 4
    Friend Const PAPER_A5 As Int32 = 5
    Friend Const PAPER_B4 As Int32 = 6
    Friend Const PAPER_ISOB4 As Int32 = 6
    Friend Const PAPER_B6 As Int32 = 7
    Friend Const PAPER_ISOB6 As Int32 = 7
    Friend Const PAPER_USLEDGER As Int32 = 9
    Friend Const PAPER_USEXECUTIVE As Int32 = 10
    Friend Const PAPER_A3 As Int32 = 11
    Friend Const PAPER_B3 As Int32 = 12
    Friend Const PAPER_ISOB3 As Int32 = 12
    Friend Const PAPER_A6 As Int32 = 13
    Friend Const PAPER_C4 As Int32 = 14
    Friend Const PAPER_C5 As Int32 = 15
    Friend Const PAPER_C6 As Int32 = 16
    Friend Const PAPER_4A0 As Int32 = 17
    Friend Const PAPER_2A0 As Int32 = 18
    Friend Const PAPER_A0 As Int32 = 19
    Friend Const PAPER_A1 As Int32 = 20
    Friend Const PAPER_A2 As Int32 = 21
    Friend Const PAPER_A7 As Int32 = 22
    Friend Const PAPER_A8 As Int32 = 23
    Friend Const PAPER_A9 As Int32 = 24
    Friend Const PAPER_A10 As Int32 = 25
    Friend Const PAPER_ISOB0 As Int32 = 26
    Friend Const PAPER_ISOB1 As Int32 = 27
    Friend Const PAPER_ISOB2 As Int32 = 28
    Friend Const PAPER_ISOB5 As Int32 = 29
    Friend Const PAPER_ISOB7 As Int32 = 30
    Friend Const PAPER_ISOB8 As Int32 = 31
    Friend Const PAPER_ISOB9 As Int32 = 32
    Friend Const PAPER_ISOB10 As Int32 = 33
    Friend Const PAPER_JISB0 As Int32 = 34
    Friend Const PAPER_JISB1 As Int32 = 35
    Friend Const PAPER_JISB2 As Int32 = 36
    Friend Const PAPER_JISB3 As Int32 = 37
    Friend Const PAPER_JISB4 As Int32 = 38
    Friend Const PAPER_JISB6 As Int32 = 39
    Friend Const PAPER_JISB7 As Int32 = 40
    Friend Const PAPER_JISB8 As Int32 = 41
    Friend Const PAPER_JISB9 As Int32 = 42
    Friend Const PAPER_JISB10 As Int32 = 43
    Friend Const PAPER_C0 As Int32 = 44
    Friend Const PAPER_C1 As Int32 = 45
    Friend Const PAPER_C2 As Int32 = 46
    Friend Const PAPER_C3 As Int32 = 47
    Friend Const PAPER_C7 As Int32 = 48
    Friend Const PAPER_C8 As Int32 = 49
    Friend Const PAPER_C9 As Int32 = 50
    Friend Const PAPER_C10 As Int32 = 51
    Friend Const PAPER_USSTATEMENT As Int32 = 52
    Friend Const PAPER_BUSINESSCARD As Int32 = 53

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetPaperDimensions")> _
    Public Shared Function GetPaperDimensions(ByVal nPaper As Int32, ByVal nUnits As Int32, ByRef pdW As Double, ByRef pdH As Double) As Boolean
    End Function
    ' Retrieve the width and height of a standard paper size.
    ' 1st parameter is a PAPER_ code.
    ' 2nd parameter is a unit code, TWUN_INCHES, TWUN_CENTIMETERS, etc.
    ' 3rd & 4th parameter are pointers to double variables that receive the width
    ' and height of the specified paper size, in the specified units.
    ' Returns TRUE(1) if successful, FALSE(0) otherwise.

    '-------- Document Feeder -------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_HasFeeder")> _
    Public Shared Function HasFeeder() As Boolean
    End Function
    ' Returns TRUE(1) if the source indicates it has a document feeder.
    ' Note: A FALSE(0) is returned if the source does not handle this inquiry.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ProbablyHasFlatbed")> _
    Public Shared Function ProbablyHasFlatbed() As Boolean
    End Function
    ' Returns TRUE(1) if we think the source has a flatbed available.
    ' It's a good guess but not a guarantee - we could be wrong.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsFeederSelected")> _
    Public Shared Function IsFeederSelected() As Boolean
    End Function
    ' Returns TRUE(1) if the document feeder is selected.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SelectFeeder")> _
    Public Shared Function SelectFeeder(ByVal bYes As Boolean) As Boolean
    End Function
    ' (Try to) select or deselect the document feeder.
    ' The document feeder, if any, is selected if bYes is non-zero.
    ' The flatbed, if any, is selected if bYes is zero.
    ' Note: A few of the scanners that have both a flatbed and 
    ' a feeder ignore this request in some circumstances.
    ' Returns TRUE(1) if successful, FALSE(0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsAutoFeedOn")> _
    Public Shared Function IsAutoFeedOn() As Boolean
    End Function
    ' Returns TRUE(1) if automatic feeding is enabled, otherwise FALSE(0).
    ' Make sure the feeder is selected before calling this function.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetAutoFeed")> _
    Public Shared Function SetAutoFeed(ByVal bYes As Boolean) As Boolean
    End Function
    ' (Try to) turn on/off automatic feeding thru the feeder.
    ' Returns TRUE(1) if successful, FALSE(0) otherwise.
    ' Note: TWAIN_AcquireMultipageFile calls TWAIN_SetAutoFeed(True).

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsFeederLoaded")> _
    Public Shared Function IsFeederLoaded() As Boolean
    End Function
    ' Returns TRUE(1) if there are documents in the feeder.
    ' Make sure the feeder is selected before calling this function.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetAutoScan")> _
    Public Shared Function SetAutoScan(ByVal bYes As Boolean) As Boolean
    End Function
    ' Setting this to TRUE gives the scanner permission to 'scan ahead'
    ' i.e. to pull pages from the feeder and scan them before 
    ' they have been requested.  On high-speed scanners, you may
    ' have to enable AutoScan to achieve the maximum scanning rate.
    ' Returns TRUE(1) if successful, FALSE(0) otherwise.
    ' This call will fail on most flatbeds & cameras, and some 'feeder'
    ' scanners.
    ' TWAIN_AcquireMultipageFile calls TWAIN_SetAutoScan(True).

    '-------- Duplex Scanning -------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetDuplexSupport")> _
    Public Shared Function GetDuplexSupport() As Int32
    End Function
    ' Query the device for duplex scanning support.
    '   Return values:
    ' 0    = no support (or error, or query not recognized)
    ' 1    = 1-pass duplex
    ' 2    = 2-pass duplex

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EnableDuplex")> _
    Public Shared Function EnableDuplex(ByVal bYes As Boolean) As Boolean
    End Function
    ' Enable (bYes not 0) or disable (bYes=0) duplex scanning.
    ' Returns TRUE(1) if successful, FALSE(0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsDuplexEnabled")> _
    Public Shared Function IsDuplexEnabled() As Boolean
    End Function
    ' Returns TRUE(1) if the device supports duplex scanning
    ' and duplex scanning is enabled.  FALSE(0) otherwise.

    '--------- Other 'exotic' capabilities --------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_HasControllableUI")> _
    Public Shared Function HasControllableUI() As Int32
    End Function
    ' Return 1 if source claims UI can be hidden (see SetHideUI above)
    ' Return 0 if source says UI *cannot* be hidden
    ' Return -1 if source (pre TWAIN 1.6) cannot answer the question.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetIndicators")> _
    Public Shared Function SetIndicators(ByVal bVisible As Boolean) As Boolean
    End Function
    ' Tell the device to show or hide progress indicators during acquisition.
    ' Default is TRUE, which gives the device permission to show a progress
    ' box or similar, but does not require it.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Compression")> _
    Public Shared Function Compression() As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCompression")> _
    Public Shared Function SetCompression(ByVal compression As Int32) As Boolean
    End Function
    ' Set/Get compression style for transferred data
    ' Set returns TRUE(1) for success, FALSE(0) for failure.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Tiled")> _
    Public Shared Function Tiled() As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetTiled")> _
    Public Shared Function SetTiled(ByVal bTiled As Boolean) As Boolean
    End Function
    ' Set/Get whether source does memory xfer via strips or tiles.
    ' bTiled = TRUE if it uses tiles for transfer.
    ' Set returns: TRUE(1) for success, FALSE(0) for failure.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_PlanarChunky")> _
    Public Shared Function PlanarChunky() As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPlanarChunky")> _
    Public Shared Function SetPlanarChunky(ByVal shape As Int32) As Boolean
    End Function
    ' Set/Get current pixel shape (TWPC_CHUNKY or TWPC_PLANAR), or -1.
    ' Set returns TRUE(1) for success, FALSE(0) for failure.

    Friend Const CHUNKY_PIXELS As Int32 = 0
    Friend Const PLANAR_PIXELS As Int32 = 1

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_PixelFlavor")> _
    Public Shared Function PixelFlavor() As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetPixelFlavor")> _
    Public Shared Function SetPixelFlavor(ByVal flavor As Int32) As Boolean
    End Function
    ' Set/Get pixel 'flavor' - whether a '0' pixel value means black or white:
    ' Set returns: TRUE(1) for success, FALSE(0) for failure.

    Friend Const CHOCOLATE_PIXELS As Int32 = 0
    Friend Const VANILLA_PIXELS As Int32 = 1


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetLightPath")> _
    Public Shared Function SetLightPath(ByVal bTransmissive As Boolean) As Boolean
    End Function
    ' Tries to select transparent or reflective media on the open source.
    ' A parameter of TRUE(1) means transparent, FALSE(0) means reflective.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetAutoBright")> _
    Public Shared Function SetAutoBright(ByVal bOn As Boolean) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetGamma")> _
    Public Shared Function SetGamma(ByVal dGamma As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetShadow")> _
    Public Shared Function SetShadow(ByVal d As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetHighlight")> _
    Public Shared Function SetHighlight(ByVal d As Double) As Boolean
    End Function
    ' Set auto-brightness, gamma, shadow, and highlight values.
    ' Refer to the TWAIN specification for definitions of these settings.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.

    '--------- Image Layout (Region of Interest) --------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetRegion")> _
    Public Shared Sub SetRegion(ByVal L As Double, ByVal T As Double, ByVal R As Double, ByVal B As Double)
    End Sub
    ' Specify the region to be acquired, in current unit of measure.
    ' This is the recommended most-general way to scan a region.
    ' Tries to use TWAIN_SetImageLayout and TWAIN_SetFrame (see below).
    ' If the device ignores those, the specified region is extracted
    ' after each scan completes, by software cropping. (DIB_RegionCopy)
    ' In other words, this call should *always* produce scans of
    ' the requested region, unless you specify a region in inches or
    ' centimeters and the device is a camera whose only unit is pixels.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ResetRegion")> _
    Public Shared Sub ResetRegion()
    End Sub
    ' Clear any region set with TWAIN_SetRegion above.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetImageLayout")> _
    Public Shared Function SetImageLayout(ByVal L As Double, ByVal T As Double, ByVal R As Double, ByVal B As Double) As Boolean
    End Function
    ' Specify the area to scan, sometimes called the ROI (Region of Interest)
    ' Returns: TRUE(1) for success, FALSE(0) for failure.
    ' This call is only valid in State 4.
    ' L, T, R, B = distance to left, top, right, and bottom edge of
    ' area to scan, measured in the current unit of measure,
    ' from the top-left corner of the 'original page' (TWAIN 1.6 8-22)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetImageLayout")> _
    Public Shared Function GetImageLayout(ByRef L As Double, ByRef T As Double, ByRef R As Double, ByRef B As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetDefaultImageLayout")> _
    Public Shared Function GetDefaultImageLayout(ByRef L As Double, ByRef T As Double, ByRef R As Double, ByRef B As Double) As Boolean
    End Function
    ' Get the current or default (power-on) area to scan.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.
    ' This call is valid in States 4-6.
    ' Supposedly the returned values (see above)
    ' are in the current unit of measure (ICAP_UNITS), but I observe that
    ' many DS's ignore ICAP_UNITS when dealing with Image Layout.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ResetImageLayout")> _
    Public Shared Function ResetImageLayout() As Boolean
    End Function
    ' Reset the area to scan to the default (power-on) settings.
    ' This call is only valid in State 4.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.


    ' Closely related:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetFrame")> _
    Public Shared Function SetFrame(ByVal L As Double, ByVal T As Double, ByVal R As Double, ByVal B As Double) As Boolean
    End Function
    ' This is an alternative way to set the scan area.
    ' Some scanners will respond to this instead of SetImageLayout.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.
    ' This call is only valid in State 4.
    ' L, T, R, B = distance to left, top, right, and bottom edge of
    ' area to scan, measured in the current unit of measure,


    '--------- Tone Response Curves --------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetGrayResponse")> _
    Public Shared Function SetGrayResponse(ByVal pcurve As Int32()) As Boolean
    End Function
    ' Define a translation of gray pixel values.
    ' When device digitizes a pixel with value V, that
    ' pixel is translated to value pcurve[V] before it
    ' is returned to the application.
    ' Device must be open (State 4),
    ' Current PixelType must be TWPT_GRAY or TWPT_RGB,
    ' current BitDepth should be 8.
    ' pcurve must be a table (array, vector) of 256 entries.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetColorResponse")> _
    Public Shared Function SetColorResponse(ByVal pred As Int32(), ByVal pgreen As Int32(), ByVal pblue As Int32()) As Boolean
    End Function
    ' Define a translation of color values.
    ' Like TWAIN_SetGrayResponse (above) but separate translation can
    ' be applied to each color channel.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ResetGrayResponse")> _
    Public Shared Function ResetGrayResponse() As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ResetColorResponse")> _
    Public Shared Function ResetColorResponse() As Boolean
    End Function
    ' These two functions reset the response curve to map every
    ' value V to itself i.e. a 'do nothing' translation.
    ' Returns: TRUE(1) for success, FALSE(0) for failure.

    '--------- Barcode Recognition -------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_IsAvailable() As Boolean
    End Function
    ' TRUE(1) if barcode recognition is available.
    ' Returns FALSE(0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_Version() As Int32
    End Function
    ' Return the barcode module version * 100.

    ' Barcode recognition engines supported by EZTwain:
    Friend Const EZBAR_ENGINE_NONE As Int32 = 0
    Friend Const EZBAR_ENGINE_DOSADI As Int32 = 1
    Friend Const EZBAR_ENGINE_AXTEL As Int32 = 2
    Friend Const EZBAR_ENGINE_LEADTOOLS As Int32 = 3
    Friend Const EZBAR_ENGINE_BLACKICE As Int32 = 4

    ' The Axtel barcode engine has been discontinued by Axtel.
    ' The LEADTOOLS engine must be separately licensed from LEADTOOLS - www.leadtools.com
    ' The Black Ice barcode engine must be separately licensed from Black Ice. 

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_IsEngineAvailable(ByVal nEngine As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_SelectEngine(ByVal nEngine As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_SelectedEngine() As Int32
    End Function

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="BARCODE_EngineName")> _
    Public Shared Function BARCODE_EngineNamePtr(ByVal nEngine As Int32) As IntPtr
    End Function
    Public Shared Function BARCODE_EngineName(ByVal nEngine As Int32) As String
        BARCODE_EngineName = Marshal.PtrToStringAnsi(BARCODE_EngineNamePtr(nEngine))
    End Function
    ' Returns the short name ("None", "Dosadi", "Axtel", "LEADTOOLS", "Black Ice") of the specified
    ' engine, or the empty string if nEngine is not a recognized barcode engine code.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub BARCODE_SetLicenseKey(ByVal sKey As String)
    End Sub
    ' Supply your license key for the currently selected engine.
    ' The Dosadi engine does not currently require a key.
    ' For LeadTools, this is a 1D Barcode Module key obtained from LeadTools

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_ReadableCodes() As Int32
    End Function
    ' Return the sum of the barcode types recognized by the current selected engine.
    '
    ' Barcode types:
    Friend Const EZBAR_EAN_13 As Int32 = &H1
    Friend Const EZBAR_EAN_8 As Int32 = &H2
    Friend Const EZBAR_UPCA As Int32 = &H4
    Friend Const EZBAR_UPCE As Int32 = &H8
    Friend Const EZBAR_CODE_39 As Int32 = &H10
    Friend Const EZBAR_CODE_39FA As Int32 = &H20
    Friend Const EZBAR_CODE_128 As Int32 = &H40
    Friend Const EZBAR_CODE_I25 As Int32 = &H80
    Friend Const EZBAR_CODA_BAR As Int32 = &H100
    Friend Const EZBAR_UCCEAN_128 As Int32 = &H200
    Friend Const EZBAR_CODE_93 As Int32 = &H400
    Friend Const EZBAR_ANY As Int32 = -1

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="BARCODE_TypeName")> _
    Public Shared Function BARCODE_TypeNamePtr(ByVal nType As Int32) As IntPtr
    End Function
    Public Shared Function BARCODE_TypeName(ByVal nType As Int32) As String
        BARCODE_TypeName = Marshal.PtrToStringAnsi(BARCODE_TypeNamePtr(nType))
    End Function
    ' Return a human-readable name for the specified barcode type/symbology.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_SetDirectionFlags(ByVal nDirFlags As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_GetDirectionFlags() As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_AvailableDirectionFlags() As Int32
    End Function
    ' Set/Get the directions the engine will scan for barcodes.
    ' The default is left-to-right ONLY.
    ' Scanning for barcodes in multiple directions can slow the
    ' recognition process.  BARCODE_SetDirectionFlags will return TRUE if
    ' completely successful, FALSE if any direction is invalid or not supported.
    ' Setting the direction flags to -1 is interpreted as "select all supported
    ' directions."

    ' Barcode direction flags - can be or'ed together
    Friend Const EZBAR_LEFT_TO_RIGHT As Int32 = &H1
    Friend Const EZBAR_RIGHT_TO_LEFT As Int32 = &H2
    Friend Const EZBAR_TOP_TO_BOTTOM As Int32 = &H4
    Friend Const EZBAR_BOTTOM_TO_TOP As Int32 = &H8
    Friend Const EZBAR_DIAGONAL As Int32 = &H10
    ' some common combinations:
    Friend Const EZBAR_HORIZONTAL As Int32 = &H3
    Friend Const EZBAR_VERTICAL As Int32 = &HC

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub BARCODE_SetZone(ByVal left As Int32, ByVal top As Int32, ByVal w As Int32, ByVal h As Int32)
    End Sub
    ' Restrict barcode recognition to one zone (in pixels) of each image.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub BARCODE_NoZone()
    End Sub
    ' Cancel any zone restriction - subsequent barcode recognition
    ' applies to the entire image.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_Recognize(ByVal hdib As IntPtr, ByVal nMaxCount As Int32, ByVal nType As Int32) As Int32
    End Function
    ' Find and recognize barcodes in the given image.
    ' Don't look for more than nMaxCount barcodes (-1 means 'any number')
    ' Expect barcodes of the specified type (-1 means 'any recognized type')
    ' You can add or 'or' together barcode types.
    '
    ' Return values:
    '   n>0    n barcodes found
    '   0      no barcodes found
    '  -1      barcode services not available.
    '       -2              -not used-
    '  -3      invalid or null image
    '       -4              memory error (low memory?)
    '  -5           internal error, or error from 3rd party barcode engine.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="BARCODE_Text")> _
    Public Shared Function BARCODE_TextPtr(ByVal n As Int32) As IntPtr
    End Function
    Public Shared Function BARCODE_Text(ByVal n As Int32) As String
        BARCODE_Text = Marshal.PtrToStringAnsi(BARCODE_TextPtr(n))
    End Function
    ' Return the text of the nth barcode recognized by the last BARCODE_Recognize.
    ' barcodes are numbered from 0.
    ' If there is any problem of any kind, returns the empty string.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_GetText(ByVal n As Int32, ByVal Text As System.Text.StringBuilder) As Boolean
    End Function
    ' Get the text of the nth barcode recognized by the last BARCODE_Recognize.
    ' Please allow 64 characters in your text buffer.  Use a smaller buffer
    ' only if you *know* that the barcode type is limited to shorter strings.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_Type(ByVal n As Int32) As Int32
    End Function
    ' Return the type (symbology) of the nth barcode recognized.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function BARCODE_GetRect(ByVal n As Int32, ByRef L As Double, ByRef T As Double, ByRef R As Double, ByRef B As Double) As Boolean
    End Function
    ' Get the rectangle bounding the nth barcode found in the last BARCODE_Recognize.
    ' Returns TRUE(1) if successful, FALSE(0) otherwise.  The only likely cause
    ' of a FALSE return would be an invalid value of n, or a null reference.
    ' L    = left edge
    ' T    = top edge
    ' R    = right edge
    ' B    = bottom edge
    ' Note: Returned coordinates are in pixels, relative to the upper-left corner
    ' of the image given to BARCODE_Recognize.

    '--------- OCR (Optical Character Recognition) -------

    ' Note: Requires the Transym OCR engine (TOCR) which must be separately
    ' licensed from Transym - See www.transym.com

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_IsAvailable() As Boolean
    End Function
    ' TRUE(1) if OCR recognition is available in some form.
    ' Returns FALSE(0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_Version() As Int32
    End Function
    ' Returns version * 100 of the EZTwain OCR module.

    ' ----- OCR engines supported by EZTwain -----
    Friend Const EZOCR_ENGINE_NONE As Int32 = 0
    Friend Const EZOCR_ENGINE_TRANSYM As Int32 = 1

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_IsEngineAvailable(ByVal nEngine As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_SelectEngine(ByVal nEngine As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_SelectedEngine() As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_SelectDefaultEngine() As Boolean
    End Function

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="OCR_EngineName")> _
    Public Shared Function OCR_EngineNamePtr(ByVal nEngine As Int32) As IntPtr
    End Function
    Public Shared Function OCR_EngineName(ByVal nEngine As Int32) As String
        OCR_EngineName = Marshal.PtrToStringAnsi(OCR_EngineNamePtr(nEngine))
    End Function
    ' Returns the short name ("None", "Transym TOCR") of the specified
    ' engine, or the empty string if nEngine is not a recognized OCR engine code.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub OCR_SetEngineKey(ByVal sKey As String)
    End Sub
    ' Set the license key to be passed to the OCR engine.
    ' * If you are using the reseller version of Transym's TOCR, pass the
    '   RegNo provided by Transym, as a string e.g. "0123-4567-89AB-CDEF"

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub OCR_SetLineBreak(ByVal sEOL As String)
    End Sub
    ' Set the character sequence to use for line breaks in
    ' the returned OCR'd text (as returned by OCR_Text and OCR_GetText).
    '
    ' The default OCR line break is \n (LF, 0x0A)
    ' Other commonly used line breaks are \r (CR, 0x0D) or CRLF.
    ' Set this *before* doing OCR - it does not modify already
    ' recognized text.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_RecognizeDib(ByVal hdib As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_RecognizeDibZone(ByVal hdib As IntPtr, ByVal left As Int32, ByVal top As Int32, ByVal w As Int32, ByVal h As Int32) As Int32
    End Function
    ' Find and recognize text in the given image, or
    ' in a designated zone of an image.
    '
    ' Return values:
    '   0           no error, but no text found
    '   n > 0       n characters found (including spaces and returns)
    '  -1           OCR services not available
    '  -3           invalid or null image
    '  -5           internal error or error returned by OCR engine
    '
    ' In case of error, call TWAIN_ReportLastError to display details,
    ' or call TWAIN_LastErrorCode and related functions.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="OCR_Text")> _
    Public Shared Function OCR_TextPtr() As IntPtr
    End Function
    Public Shared Function OCR_Text() As String
        OCR_Text = Marshal.PtrToStringAnsi(OCR_TextPtr())
    End Function
    ' Return the text found by the last OCR_RecognizeDib
    ' If there is any problem of any kind, returns the empty string.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_GetText(ByVal TextBuffer As System.Text.StringBuilder, ByVal nBufLen As Int32) As Boolean
    End Function
    ' Read the text recognized by the last OCR_RecognizeDib
    ' into the TextBuffer, which is allocated to hold nBufLen chars.
    ' Returns the number of characters actually returned.
    ' Always appends a trailing 0 (NUL).
    ' Will return 0 if the available text does not fit.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_TextLength() As Int32
    End Function
    ' Returns the number of characters in OCR_Text.
    ' Does not count the terminal NUL,
    ' for those of you working with C-style strings.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_TextOrientation() As Int32
    End Function
    ' Returns the orientation of the text found by the last OCR_RecognizeDib.
    ' The value is the number of degrees clockwise that the input
    ' image was auto-rotated before OCR was performed.
    ' Currently, the returned value is always a multiple of 90,
    ' The only possible values are 0, 90, 180 and 270.
    ' Example: If the original was turned 90 degrees clockwise before scanning,
    ' it will be auto-rotated 90 degrees *counter-clockwise* before OCR, so
    ' then the value of this function will be 270.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_GetCharPositions(ByVal charx As Int32(), ByVal chary As Int32()) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_GetCharSizes(ByVal charw As Int32(), ByVal charh As Int32()) As Boolean
    End Function
    ' Return the coordinates or sizes of the characters found by the last
    ' OCR_RecognizeDib call.
    ' For each character of the string returned by OCR_Text or OCR_GetText,
    ' these functions return the x and y coordinates in the array charx and chary,
    ' and the width and height in the arrays charw and charh.
    ' So (charx[i],chary[i]) will be the position of the ith character.
    ' Coordinates are for the top-left corner of the character, relative
    ' to the top-left corner of the OCR'd image.
    ' Width and height are in pixels.
    '
    ' Please make *sure* that you pass in (the address/reference of)
    ' two arrays allocated to hold n values, where n is the return
    ' value from the last call to OCR_Recognize.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub OCR_GetResolution(ByRef xdpi As Double, ByRef ydpi As Double)
    End Sub
    ' Return the resolution (in DPI) of the last image given to OCR_RecognizeDib.
    ' Useful for translating pixel coordinates and sizes into physical (inch) values.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub OCR_ClearText()
    End Sub
    ' Clear any currently stored OCR text.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_WritePage(ByVal hdib As IntPtr) As Boolean
    End Function
    ' If an OCR engine is selected and available, and there is
    ' a PDF file open for writing (by TWAIN_BeginMultipageFile), then
    ' this function OCRs the image, and writes both the image and
    ' the text to the output PDF.
    '
    ' Returns TRUE if successful, FALSE otherwise:
    ' In case of error, call TWAIN_ReportLastError to display details,
    ' or call TWAIN_LastErrorCode and related functions.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function OCR_WriteTextToPDF() As Boolean
    End Function
    ' Write the text from the last OCR to the next PDF page.
    ' Returns TRUE if successful, FALSE in case of error.
    ' If there is no OCR text to write, does nothing & returns TRUE.

    '--------- Fun With Containers --------

    ' Capability values are passed thru the TWAIN API in complex global
    ' memory structures called 'containers'.  EZTWAIN abstracts these
    ' containers with a handle (an integer) called an HCONTAINER.
    ' If you are coding in VB or similar, this is a 32-bit integer.
    ' The following functions provide reasonably comprehensive access
    ' to the contents of containers.  See also TWAIN_Get, TWAIN_Set.
    '
    ' There are four shapes of containers, which I call 'formats'.
    ' Depending on its format, a container holds some 'items' - these
    ' are simple data values, all the same type in a given container.
    ' Item types are enumerated by TWTY_*

    ' Container formats, same codes as in TWAIN.H
    Friend Const TWON_ARRAY As Int32 = 3
    Friend Const TWON_ENUMERATION As Int32 = 4
    Friend Const TWON_ONEVALUE As Int32 = 5
    Friend Const TWON_RANGE As Int32 = 6


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub CONTAINER_Free(ByVal hcon As IntPtr)
    End Sub
    ' Free the memory and resources of a capability container.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_Copy(ByVal hcon As IntPtr) As IntPtr
    End Function
    ' Create an exact copy of the container.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_Equal(ByVal hconA As IntPtr, ByVal hconB As IntPtr) As Boolean
    End Function
    ' Return TRUE (1) iff all properties of hconA and hconB are the same.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_Format(ByVal hcon As IntPtr) As Int32
    End Function
    ' Return the 'format' of this container: TWON_ONEVALUE, etc.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_ItemCount(ByVal hcon As IntPtr) As Int32
    End Function
    ' Return the number of values in the container.
    ' For a ONEVALUE, return 1.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_ItemType(ByVal hcon As IntPtr) As Int32
    End Function
    ' Return the item type (what exact kind of values are in the container.)
    ' See the TWTY_* definitions in TWAIN.H

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_TypeSize(ByVal nItemType As Int32) As Int32
    End Function
    ' Return the size in bytes of an item of the specified type (TWTY_*)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Sub CONTAINER_GetStringValue(ByVal hcon As IntPtr, ByVal n As Int32, ByVal sText As System.Text.StringBuilder)
    End Sub
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_FloatValue(ByVal hcon As IntPtr, ByVal n As Int32) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_IntValue(ByVal hcon As IntPtr, ByVal n As Int32) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="CONTAINER_StringValue")> _
    Public Shared Function CONTAINER_StringValuePtr(ByVal hcon As IntPtr, ByVal n As Int32) As IntPtr
    End Function
    Public Shared Function CONTAINER_StringValue(ByVal hcon As IntPtr, ByVal n As Int32) As String
        CONTAINER_StringValue = Marshal.PtrToStringAnsi(CONTAINER_StringValuePtr(hcon, n))
    End Function
    ' Get the value of the nth item in the container.
    ' n is forced into the range 0 to ItemCount(hcon)-1.
    ' For string values, if the container items are not strings, they
    ' are converted to an equivalent string (e.g. "TRUE", "23", "2.37", etc.)


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_ContainsValue(ByVal hcon As IntPtr, ByVal d As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_ContainsValueInt(ByVal hcon As IntPtr, ByVal n As Int32) As Boolean
    End Function
    ' Return TRUE(1) if the value is one of the items in the container.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_FindValue(ByVal hcon As IntPtr, ByVal d As Double) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_FindValueInt(ByVal hcon As IntPtr, ByVal n As Int32) As Int32
    End Function
    ' Return the 0-origin index of the value in the container.
    ' Return -1 if not found.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_CurrentValue(ByVal hcon As IntPtr) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_DefaultValue(ByVal hcon As IntPtr) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_CurrentValueInt(ByVal hcon As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_DefaultValueInt(ByVal hcon As IntPtr) As Int32
    End Function
    ' Return the container's current or power-up (default) value.
    ' Array containers do not have these and will return -1.0.
    ' OneValue containers always return their (one) value.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_DefaultIndex(ByVal hcon As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_CurrentIndex(ByVal hcon As IntPtr) As Int32
    End Function
    ' Return the index of the Default or Current value.
    ' Works on Enumerations, Ranges and OneValues.
    ' (Always returns 0 for a OneValue)
    ' Returns -1 for an Array.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_MinValue(ByVal hcon As IntPtr) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_MaxValue(ByVal hcon As IntPtr) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_MinValueInt(ByVal hcon As IntPtr) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_MaxValueInt(ByVal hcon As IntPtr) As Int32
    End Function
    ' Return the smallest/largest value in the container.
    ' For a OneValue, this is just the value.
    ' For a Range, these are the Min and Max values of the range.
    ' For an Array or Enumeration, the container is searched to find
    ' the smallest/largest value.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_StepSize(ByVal hcon As IntPtr) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_StepSizeInt(ByVal hcon As IntPtr) As Int32
    End Function
    ' Return the 'step' value of a Range container.
    ' Returns -1 if the container is not a Range.

    ' The following four functions create containers from scratch:
    ' nItemType is one of the TWTY_* item types from TWAIN.H
    ' nItems is the number of items, in an array or enumeration.
    ' dMin, dMax, dStep are the beginning, ending, and step value of a range.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_OneValue(ByVal nItemType As Int32, ByVal dVal As Double) As IntPtr
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_Range(ByVal nItemType As Int32, ByVal dMin As Double, ByVal dMax As Double, ByVal dStep As Double) As IntPtr
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_Array(ByVal nItemType As Int32, ByVal nItems As Int32) As IntPtr
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_Enumeration(ByVal nItemType As Int32, ByVal nItems As Int32) As IntPtr
    End Function

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_SetItem(ByVal hcon As IntPtr, ByVal n As Int32, ByVal dVal As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_SetItemInt(ByVal hcon As IntPtr, ByVal n As Int32, ByVal nVal As Int32) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_SetItemString(ByVal hcon As IntPtr, ByVal n As Int32, ByVal sVal As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_SetItemFrame(ByVal hcon As IntPtr, ByVal n As Int32, ByVal l As Double, ByVal t As Double, ByVal r As Double, ByVal b As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_GetItemFrame(ByVal hcon As IntPtr, ByVal n As Int32, ByRef L As Double, ByRef T As Double, ByRef R As Double, ByRef B As Double) As Boolean
    End Function
    ' Set(or get) the nth item of the container to dVal or pzText, or frame(l,t,r,b).
    ' NOTE: A OneValue is treated as an array with 1 element. 
    ' Return TRUE(1) if successful. FALSE(0) for error such as:
    '    The container is not an array, enumeration, or onevalue
    '    n < 0 or n >= CONTAINER_ItemCount(hcon)
    '    the value cannot be represented in this container's ItemType.
    ' Frame operations fail if the CONTAINER_ItemType is not TWTY_FRAME.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_SelectCurrentValue(ByVal hcon As IntPtr, ByVal dVal As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_SelectCurrentItem(ByVal hcon As IntPtr, ByVal n As Int32) As Boolean
    End Function
    ' Select the current value within an enumeration or range,
    ' by specifying either the value, or its index.
    ' Returns TRUE(1) if successful, FALSE(0) otherwise.
    ' This will fail if:
    '    The container is not an enumeration or range.
    '    dVal is not one of the values in the container
    '    n < 0 or n >= CONTAINER_ItemCount(hcon)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_SelectDefaultValue(ByVal hcon As IntPtr, ByVal dVal As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_SelectDefaultItem(ByVal hcon As IntPtr, ByVal n As Int32) As Boolean
    End Function
    ' Select the default value in an enumeration or range.
    ' We're not sure what this would be good for, since an application
    ' cannot change the default value of a capability - that value is
    ' determined by the device TWAIN driver.
    ' So these functions are for logical completeness only.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_DeleteItem(ByVal hcon As IntPtr, ByVal n As Int32) As Boolean
    End Function
    ' Delete the nth item from an Array or Enumeration container.
    ' Returns TRUE(1) for success, FALSE(0) otherwise. Failure causes:
    '   invalid container handle
    '   container is not an array or enumeration
    '   n < 0 or n >= ItemCount(hcon)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_InsertItem(ByVal hcon As IntPtr, ByVal n As Int32, ByVal dVal As Double) As Boolean
    End Function
    ' Insert an item with value dVal into the container at position n.
    ' If n < 0, the item is inserted at the end of the container.
    ' Return TRUE(1) on success, FALSE(0) on failure.
    ' Possible causes of failure:
    '   NULL or invalid container handle
    '   container format is not enumeration or array
    '   memory allocation failed - heap corrupted, or out of memory.

    '--- Very low level CONTAINER functions you probably won't need:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_Wrap(ByVal nFormat As Int32, ByVal hcon As IntPtr) As IntPtr
    End Function
    ' Wrap a TWAIN container handle into an HCONTAINER object.
    ' Note: *Do Not* free the hcon - it is now owned by the HCONTAINER.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_Unwrap(ByVal hcon As IntPtr) As IntPtr
    End Function
    ' Unwrap a TWAIN container from an HCONTAINER object - free the
    ' HCONTAINER and return the original TWAIN container handle.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_Handle(ByVal hcon As IntPtr) As IntPtr
    End Function
    ' Retrieve the handle of the TWAIN container wrapped in our HCONTAINER
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False)> _
    Public Shared Function CONTAINER_IsValid(ByVal hcon As IntPtr) As Boolean
    End Function
    ' Return TRUE if the argument seems to be a valid HCONTAINER object.

    '--------- Low-level Capability Negotiation Functions --------

    ' Setting a capability is valid only in State 4 (TWAIN_SOURCE_OPEN)
    ' Getting a capability is valid in State 4 or any higher state.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsCapAvailable")> _
    Public Shared Function IsCapAvailable(ByVal uCap As Int32) As Boolean
    End Function
    ' Test if open device responds to a 'Get' on a capability.
    ' Only valid in State 4 or higher.
    ' Returns TRUE(1) if the capability can be queried, FALSE(0) if not.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Get")> _
    Public Shared Function GetCap(ByVal uCap As Int32) As IntPtr
    End Function
    ' Issue a DAT_CAPABILITY/MSG_GET to the open source.
    ' Return a capability 'container' - the 'MSG_GET' value of the capability.
    ' Use CONTAINER_* functions to examine and modify the container object.
    ' Use CONTAINER_Free to release it when you are done with it.
    ' A return value of 0 indicates failure:  Call GetConditionCode
    ' or ReportLastError above.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetDefault")> _
    Public Shared Function GetDefault(ByVal uCap As Int32) As IntPtr
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCurrent")> _
    Public Shared Function GetCurrent(ByVal uCap As Int32) As IntPtr
    End Function
    ' Issue a DAT_CAPABILITY/MSG_GETDEFAULT or MSG_GETCURRENT.  See Get above.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Set")> _
    Public Shared Function SetCap(ByVal uCap As Int32, ByVal hcon As IntPtr) As Boolean
    End Function
    ' Issue a DAT_CAPABILITY/MSG_SET to the open source,
    ' using the specified capability and container.
    ' Return value as for TWAIN_DS

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Reset")> _
    Public Shared Function Reset(ByVal uCap As Int32) As Boolean
    End Function
    ' Issue a MSG_RESET on the specified capability.
    ' State must be 4.  Returns TRUE(1) if successful, FALSE(0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_QuerySupport")> _
    Public Shared Function QuerySupport(ByVal uCap As Int32) As Int32
    End Function
    ' Issue a MSG_QUERYSUPPORT on the specified capability.
    ' State must be 4 or higher.  Returns the integer value that the device
    ' returned, which can be 0.
    ' A return < 0 indicates an error.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCapability")> _
    Public Shared Function SetCapability(ByVal cap As Int32, ByVal dValue As Double) As Boolean
    End Function
    ' The most general capability-setting function, it negotiates
    ' with the open device to set the given capability to the specified value.
    ' If successful, returns TRUE(1), otherwise FALSE(0).
    ' There must be a device open and in state 4, or an error is recorded.
    ' (See TWAIN_ReportLastError.)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCapString")> _
    Public Shared Function SetCapString(ByVal cap As Int32, ByVal sValue As String) As Boolean
    End Function
    ' Set the value of a capability that takes a string value.
    ' You don't need to specify the 'itemType', EZTwain asks the driver
    ' which itemType it wants.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCapBool")> _
    Public Shared Function SetCapBool(ByVal cap As Int32, ByVal bValue As Boolean) As Boolean
    End Function
    ' Shorthand for TWAIN_SetCapOneValue(cap, TWTY_BOOL, bValue);

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCapBool")> _
    Public Shared Function GetCapBool(ByVal cap As Int32, ByVal bDefault As Boolean) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCapFix32")> _
    Public Shared Function GetCapFix32(ByVal cap As Int32, ByVal dDefault As Double) As Double
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCapUint16")> _
    Public Shared Function GetCapUint16(ByVal cap As Int32, ByVal nDefault As Int32) As Int32
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCapUint32")> _
    Public Shared Function GetCapUint32(ByVal cap As Int32, ByVal lDefault As Int32) As Int32
    End Function
    ' Issue a DAT_CAPABILITY/MSG_GETCURRENT on the specified capability,
    ' assuming the value type is Bool, Fix32, etc..
    ' If successful, return the returned value.  Otherwise return bDefault.
    ' This is only valid in State 4 (TWAIN_SOURCE_OPEN) or higher.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCapFix32")> _
    Public Shared Function SetCapFix32(ByVal Cap As Int32, ByVal dVal As Double) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCapOneValue")> _
    Public Shared Function SetCapOneValue(ByVal Cap As Int32, ByVal ItemType As Int32, ByVal ItemVal As Int32) As Boolean
    End Function
    ' Do a DAT_CAPABILITY/MSG_SET, on capability 'Cap' (e.g. ICAP_PIXELTYPE,
    ' CAP_AUTOFEED, etc.) using a TW_ONEVALUE container with the given item type
    ' and value.  Use SetCapFix32 for capabilities that take a FIX32 value,
    ' use SetCapOneValue for the various ints and uints.  These functions
    ' do not support FRAME or STR items.
    ' Return Value: TRUE (1) if successful, FALSE (0) otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCapFix32R")> _
    Public Shared Function SetCapFix32R(ByVal Cap As Int32, ByVal Numerator As Int32, ByVal Denominator As Int32) As Boolean
    End Function
    ' Just like TWAIN_SetCapFix32, but uses the value Numerator/Denominator
    ' This is useful for languages that make it hard to pass double parameters.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCapCurrent")> _
    Public Shared Function GetCapCurrent(ByVal Cap As Int32, ByVal ItemType As Int32, ByVal pVal As IntPtr) As Boolean
    End Function
    ' Do a DAT_CAPABILITY/MSG_GETCURRENT on capability 'Cap'.
    ' Copy the current value out of the returned container into *pVal.
    ' If the operation fails (the source refuses the request), or if the
    ' container is not a ONEVALUE or ENUMERATION, or if the item type of the
    ' returned container is incompatible with the expected TWTY_ type in nType,
    ' returns FALSE.  If this function returns FALSE, *pVal is not touched.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ToFix32")> _
    Public Shared Function ToFix32(ByVal d As Double) As Int32
    End Function
    ' Convert a floating-point value to a 32-bit TW_FIX32 value that can be passed
    ' to e.g. TWAIN_SetCapOneValue
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ToFix32R")> _
    Public Shared Function ToFix32R(ByVal Numerator As Int32, ByVal Denominator As Int32) As Int32
    End Function
    ' Convert a rational number to a 32-bit TW_FIX32 value.
    ' Returns a TW_FIX32 value that approximates Numerator/Denominator

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Fix32ToFloat")> _
    Public Shared Function Fix32ToFloat(ByVal nfix As Int32) As Double
    End Function
    ' Convert a TW_FIX32 value (as returned from some capability inquiries)
    ' to a double (floating point) value.


    '--------- Custom DS Data
    '
    ' The following functions support the relatively exotic CUSTOMDSDATA feature
    ' introduced in TWAIN 1.7.  This feature, if supported by a device, allows
    ' the application to read and set, all the settings of the device
    ' simultaneously with one block of data.  *The format of the data is defined
    ' by each device* and is undocumented.  So this is just a way to capture
    ' a snapshot of a particular device's settings, and then to
    ' restore that state at a later time.
    '
    ' To find out if a device supports this feature, open the device and see if
    ' TWAIN_GetCapBool(CAP_CUSTOMDSDATA, FALSE) returns TRUE.
    '
    ' The TWAIN_State() must be 4 or these functions will display an error.
    '
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetCustomDataToFile")> _
    Public Shared Function GetCustomDataToFile(ByVal sFilename As String) As Boolean
    End Function
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetCustomDataFromFile")> _
    Public Shared Function SetCustomDataFromFile(ByVal sFilename As String) As Boolean
    End Function
    ' Both functions return TRUE(1) if successful, FALSE(0) otherwise.
    ' These functions will display an error message if called outside State 4.
    ' In case of failure, call LastErrorCode, ReportLastError, etc. for details.
    ' No file extension is assumed, you should provide one, such as ".dat".

    '--------- Extended Image Info
    '
    ' The following functions support the 'Extended Image Info' feature of TWAIN,
    ' which is implemented by only a few TWAIN drivers.  This consists of special
    ' information, sometimes called 'metadata' which can be collected about
    ' each scanned image, in addition to the image itself.
    ' Examples of extended image info include
    ' TWEI_BARCODETEXT - text of a barcode found in the scan
    ' TWEI_SKEWORIGINALANGLE - the amount of 'skew' in the original raw scan
    ' See the TWAIN Specification (version 1.9 or later) for details.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsExtendedInfoSupported")> _
    Public Shared Function IsExtendedInfoSupported() As Boolean
    End Function
    ' Asks the currently open device if it supports Extended Image Info.
    ' Returns TRUE(1) if yes, FALSE(0) if not.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EnableExtendedInfo")> _
    Public Shared Function EnableExtendedInfo(ByVal eiCode As Int32, ByVal enabled As Boolean) As Boolean
    End Function
    ' Enable or disable collection of a particular kind of extended image info.
    ' Each type of information is represented by an integer constant with
    ' prefix TWEI_ see the list of constants elsewhere in this file.
    ' There is a limit to how many different info types can be enabled at the
    ' same time.  If this limit is exceeded, this function returns FALSE
    ' and has no effect.  Otherwise (if successful) it returns TRUE.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_IsExtendedInfoEnabled")> _
    Public Shared Function IsExtendedInfoEnabled(ByVal eiCode As Int32) As Boolean
    End Function
    ' Return TRUE if the specified extended image type is enabled
    ' (for collection)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DisableExtendedInfo")> _
    Public Shared Sub DisableExtendedInfo()
    End Sub
    ' Disables all extended image info - none is collected after this.

    ' After a successful scan, you can use the following functions to
    ' retrieve the extended image info associated with that scan:
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ExtendedInfoItemCount")> _
    Public Shared Function ExtendedInfoItemCount(ByVal eiCode As Int32) As Int32
    End Function
    ' Return the number of items of data available of the given info type.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ExtendedInfoItemType")> _
    Public Shared Function ExtendedInfoItemType(ByVal eiCode As Int32) As Int32
    End Function
    ' Return a number indicating the type of data returned for the specified extended info.
    ' Returns the same TWTY_ codes as CONTAINER_ItemType.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ExtendedInfoInt")> _
    Public Shared Function ExtendedInfoInt(ByVal eiCode As Int32, ByVal n As Int32) As Int32
    End Function
    ' Return the (integer) value of the 'nth' item of the specified extended info.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ExtendedInfoFloat")> _
    Public Shared Function ExtendedInfoFloat(ByVal eiCode As Int32, ByVal n As Int32) As Double
    End Function
    ' Return the (floating point) value of the 'nth' item of the specified extended info.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetExtendedInfoString")> _
    Public Shared Function GetExtendedInfoString(ByVal eiCode As Int32, ByVal n As Int32, ByVal Buffer As System.Text.StringBuilder, ByVal Bufsize As Int32) As Boolean
    End Function
    ' Read the (string) value of the nth item of the specified info type into Buffer,
    ' which has been allocated by the caller to hold Bufsize characters.
    ' Note that the value returned is ASCII (byte) text, not unicode, and *always*
    ' includes an ending 0 byte, even if it must be truncated to fit.
    ' Returns TRUE if the data was retrieved and could fit in the buffer.
    ' Returns FALSE otherwise.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_ExtendedInfoString")> _
    Public Shared Function ExtendedInfoStringPtr(ByVal eiCode As Int32, ByVal n As Int32) As IntPtr
    End Function
    Public Shared Function ExtendedInfoString(ByVal eiCode As Int32, ByVal n As Int32) As String
        ExtendedInfoString = Marshal.PtrToStringAnsi(ExtendedInfoStringPtr(eiCode, n))
    End Function
    ' As above, but the string is returned as a temporary pointer to a
    ' 0-terminated ASCII string.
    ' In case of any failure, returns the empty string ("").

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetExtendedInfoFrame")> _
    Public Shared Function GetExtendedInfoFrame(ByVal eiCode As Int32, ByVal n As Int32, ByRef L As Double, ByRef T As Double, ByRef R As Double, ByRef B As Double) As Boolean
    End Function
    ' Fetch the TW_FRAME value of the 'nth' item of the specified extended info.
    ' This is rarely used, but is here for completeness.

    ' Extended Image Info codes
    Friend Const TWEI_BARCODEX As Int32 = &H1200
    Friend Const TWEI_BARCODEY As Int32 = &H1201
    Friend Const TWEI_BARCODETEXT As Int32 = &H1202
    Friend Const TWEI_BARCODETYPE As Int32 = &H1203
    Friend Const TWEI_DESHADETOP As Int32 = &H1204
    Friend Const TWEI_DESHADELEFT As Int32 = &H1205
    Friend Const TWEI_DESHADEHEIGHT As Int32 = &H1206
    Friend Const TWEI_DESHADEWIDTH As Int32 = &H1207
    Friend Const TWEI_DESHADESIZE As Int32 = &H1208
    Friend Const TWEI_SPECKLESREMOVED As Int32 = &H1209
    Friend Const TWEI_HORZLINEXCOORD As Int32 = &H120A
    Friend Const TWEI_HORZLINEYCOORD As Int32 = &H120B
    Friend Const TWEI_HORZLINELENGTH As Int32 = &H120C
    Friend Const TWEI_HORZLINETHICKNESS As Int32 = &H120D
    Friend Const TWEI_VERTLINEXCOORD As Int32 = &H120E
    Friend Const TWEI_VERTLINEYCOORD As Int32 = &H120F
    Friend Const TWEI_VERTLINELENGTH As Int32 = &H1210
    Friend Const TWEI_VERTLINETHICKNESS As Int32 = &H1211
    Friend Const TWEI_PATCHCODE As Int32 = &H1212
    Friend Const TWEI_ENDORSEDTEXT As Int32 = &H1213
    Friend Const TWEI_FORMCONFIDENCE As Int32 = &H1214
    Friend Const TWEI_FORMTEMPLATEMATCH As Int32 = &H1215
    Friend Const TWEI_FORMTEMPLATEPAGEMATCH As Int32 = &H1216
    Friend Const TWEI_FORMHORZDOCOFFSET As Int32 = &H1217
    Friend Const TWEI_FORMVERTDOCOFFSET As Int32 = &H1218
    Friend Const TWEI_BARCODECOUNT As Int32 = &H1219
    Friend Const TWEI_BARCODECONFIDENCE As Int32 = &H121A
    Friend Const TWEI_BARCODEROTATION As Int32 = &H121B
    Friend Const TWEI_BARCODETEXTLENGTH As Int32 = &H121C
    Friend Const TWEI_DESHADECOUNT As Int32 = &H121D
    Friend Const TWEI_DESHADEBLACKCOUNTOLD As Int32 = &H121E
    Friend Const TWEI_DESHADEBLACKCOUNTNEW As Int32 = &H121F
    Friend Const TWEI_DESHADEBLACKRLMIN As Int32 = &H1220
    Friend Const TWEI_DESHADEBLACKRLMAX As Int32 = &H1221
    Friend Const TWEI_DESHADEWHITECOUNTOLD As Int32 = &H1222
    Friend Const TWEI_DESHADEWHITECOUNTNEW As Int32 = &H1223
    Friend Const TWEI_DESHADEWHITERLMIN As Int32 = &H1224
    Friend Const TWEI_DESHADEWHITERLAVE As Int32 = &H1225
    Friend Const TWEI_DESHADEWHITERLMAX As Int32 = &H1226
    Friend Const TWEI_BLACKSPECKLESREMOVED As Int32 = &H1227
    Friend Const TWEI_WHITESPECKLESREMOVED As Int32 = &H1228
    Friend Const TWEI_HORZLINECOUNT As Int32 = &H1229
    Friend Const TWEI_VERTLINECOUNT As Int32 = &H122A
    Friend Const TWEI_DESKEWSTATUS As Int32 = &H122B
    Friend Const TWEI_SKEWORIGINALANGLE As Int32 = &H122C
    Friend Const TWEI_SKEWFINALANGLE As Int32 = &H122D
    Friend Const TWEI_SKEWCONFIDENCE As Int32 = &H122E
    Friend Const TWEI_SKEWWINDOWX1 As Int32 = &H122F
    Friend Const TWEI_SKEWWINDOWY1 As Int32 = &H1230
    Friend Const TWEI_SKEWWINDOWX2 As Int32 = &H1231
    Friend Const TWEI_SKEWWINDOWY2 As Int32 = &H1232
    Friend Const TWEI_SKEWWINDOWX3 As Int32 = &H1233
    Friend Const TWEI_SKEWWINDOWY3 As Int32 = &H1234
    Friend Const TWEI_SKEWWINDOWX4 As Int32 = &H1235
    Friend Const TWEI_SKEWWINDOWY4 As Int32 = &H1236
    Friend Const TWEI_BOOKNAME As Int32 = &H1238
    Friend Const TWEI_CHAPTERNUMBER As Int32 = &H1239
    Friend Const TWEI_DOCUMENTNUMBER As Int32 = &H123A
    Friend Const TWEI_PAGENUMBER As Int32 = &H123B
    Friend Const TWEI_CAMERA As Int32 = &H123C
    Friend Const TWEI_FRAMENUMBER As Int32 = &H123D
    Friend Const TWEI_FRAME As Int32 = &H123E
    Friend Const TWEI_PIXELFLAVOR As Int32 = &H123F



    '--------- Lowest-level functions for TWAIN protocol --------


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_DS")> _
    Public Shared Function DS(ByVal DG As Int32, ByVal DAT As Int32, ByVal MSG As Int32, ByVal pData As IntPtr) As Boolean
    End Function
    ' Pass the triplet (DG, DAT, MSG, pData) to the open data source if any.
    ' Returns TRUE(1) if the result code is TWRC_SUCCESS, FALSE(0) otherwise.
    ' The last result code can be retrieved with TWAIN_GetResultCode(), and the
    ' corresponding condition code can be retrieved with TWAIN_GetConditionCode().
    ' If no source is open this call will fail, result code TWRC_FAILURE,
    ' condition code TWCC_NODS.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Mgr")> _
    Public Shared Function Mgr(ByVal DG As Int32, ByVal DAT As Int32, ByVal MSG As Int32, ByVal pData As IntPtr) As Boolean
    End Function
    ' Pass a triplet to the Data Source Manager (DSM).
    ' Returns TRUE(1) for success, FALSE(0) otherwise.
    ' See GetResultCode, GetConditionCode, and ReportLastError functions
    ' for diagnosing and reporting a TWAIN_Mgr failure.
    ' If the Source Manager is not open, this call fails setting result code
    ' TWRC_FAILURE, and condition code=TWCC_SEQERROR (triplet out of sequence).


    '--------- Advanced / Exotic --------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetImageReadyTimeout")> _
    Public Shared Function SetImageReadyTimeout(ByVal nSec As Int32) As Int32
    End Function
    ' Set the maximum seconds to wait for an image-ready notification,
    ' (when one is expected i.e. after an enable) before posting a
    ' dialog that says 'Waiting for <device>' - with a Cancel button.
    ' Returns the previous setting.
    ' ** Default is -1 which disables this feature.
    ' With certain scanners there is a long delay between when the scanner
    ' is enabled and when it says "ready to scan".  Also, we have found
    ' a few scanners that intermittently fail to send "ready to scan" - by
    ' setting this timeout, you give your users a way to recover from
    ' this failure (otherwise the application has to be forcibly terminated.)

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_AutoClickButton")> _
    Public Shared Sub AutoClickButton(ByVal sButtonName As String)
    End Sub
    ' Calling this function before scanning tells EZTwain to attempt to
    ' automatically press a button when the device dialog appears.
    ' If you pass a null button name, EZTwain tries a number
    ' of likely choices (in English) including:
    ' "Scan" "Capture" "Acquire" "Scan Now" "Start Scan"  "Start Scanning"
    ' Case is ignored in the comparison ("SCAN" and "scan" are equivalent.)
    ' This function is useful when you want to automate operation of
    ' a device that insists on showing its user interface. 

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_BreakModalLoop")> _
    Public Shared Sub BreakModalLoop()
    End Sub
    ' Expert: If EZTwain is hung inside an Acquire or GetMessage loop waiting for
    ' something to happen, this function will break the loop, as if the pending
    ' transfer had failed.  TWAIN_State() will be valid, and you will need to
    ' call appropriate functions to transition TWAIN as desired.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_EmptyMessageQueue")> _
    Public Shared Sub EmptyMessageQueue()
    End Sub
    ' Expert: Get and process any pending Windows messages for this thread.
    ' For example, keystrokes or mouse clicks.  Calling this during
    ' long processes will allow the user to interact with the UI.
    ' Use only if you understand the message pump.

    '--------- Dosadi Special --------

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_BuildName")> _
    Public Shared Function BuildNamePtr() As IntPtr
    End Function
    Public Shared Function BuildName() As String
        BuildName = Marshal.PtrToStringAnsi(BuildNamePtr())
    End Function
    ' Return a string describing the build of EZTWAIN e.g. "Release - Build 6"

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetBuildName")> _
    Public Shared Sub GetBuildName(ByVal sName As System.Text.StringBuilder)
    End Sub
    ' Like TWAIN_BuildName, but copies the build string into its parameter.
    ' The parameter is a string variable (char array in C/C++).
    ' You are responsible for allocating room for 128 8-bit characters
    ' in the string variable before calling this function.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetSourceIdentity")> _
    Public Shared Function GetSourceIdentity(ByVal ptwid As IntPtr) As Int32
    End Function

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_GetImageInfo")> _
    Public Shared Function GetImageInfo(ByVal ptwinfo As IntPtr) As Int32
    End Function
    ' Issue a DG_IMAGE / DAT_IMAGEINFO / MSG_GET placing the returned data
    ' at ptwinfo.  The returned structure is a TW_IMAGEINFO - see twain.h.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_LogFile")> _
    Public Shared Sub LogFile(ByVal fLog As Int32)
    End Sub
    ' Turn logging eztwain.log on or off.
    ' By default the log file is written to C:\ but this
    ' can be overridden, see TWAIN_SetLogFolder below.
    '
    ' fLog = 0    close log file and turn off logging
    ' The following flags can be combined to enable logging:
    ' 1            basic logging of TWAIN and EZTwain operations.
    ' 2            flush log constantly (use if EZTwain crashes)
    ' 4            log Windows messages flowing through EZTwain
    Friend Const EZT_LOG_ON As Int32 = 1
    Friend Const EZT_LOG_FLUSH As Int32 = 2
    Friend Const EZT_LOG_DETAIL As Int32 = 4


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetLogFolder")> _
    Public Shared Function SetLogFolder(ByVal sFolder As String) As Boolean
    End Function
    ' Specify the folder (directory) where the log file
    ' should be placed.  Default is "c:\" - the root of the C: drive.
    ' EZTwain appends a trailing 'slash' if needed.
    ' Passing NULL or "" resets to the default: "c:\"
    '
    ' If the file cannot be created in this folder, EZTwain tries
    ' to create it in the Windows temp folder - this varies somewhat
    ' by Windows version, search for the Windows API call GetTempPath.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SetLogName")> _
    Public Shared Function SetLogName(ByVal sName As String) As Boolean
    End Function
    ' Set the filename or path & filename of the EZTwain log file.
    ' If there is a log file open, it is closed, renamed & re-opened.
    ' The default extension is ".log".
    ' The default log filename is "eztwain.log".
    '
    ' You can specify a fully-qualified filename, which changes
    ' both the folder and filename for logging:
    ' TWAIN_SetLogName("c:\temp\scan2tape.log")

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_LogFileName")> _
    Public Shared Function LogFileNamePtr() As IntPtr
    End Function
    Public Shared Function LogFileName() As String
        LogFileName = Marshal.PtrToStringAnsi(LogFileNamePtr())
    End Function
    ' Return the (fully qualified) file path and name for logging.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_WriteToLog")> _
    Public Shared Sub WriteToLog(ByVal sText As String)
    End Sub
    ' Write text to the EZTwain log file (c:\eztwain.log)
    ' If the text does not end with a newline, one is supplied.
    ' If logging is turned off, this call has no effect.
    ' Logging is controlled by TWAIN_LogFile - see above.


    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_SelfTest")> _
    Public Shared Function SelfTest(ByVal f As Int32) As Int32
    End Function
    ' Perform internal self-test.
    '   f      ignored for now
    ' Return value:
    '   0      success
    '   other  internal test failed.

    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_Blocked")> _
    Public Shared Function Blocked() As Boolean
    End Function
    ' Returns TRUE(1) if processing is inside TWAIN (Source Manager or a DS)
    ' FALSE(0) otherwise.  If the former, making any TWAIN call will
    ' fail immediately or deadlock the application (Not recommended.)


    ' Deprecated - still work, don't use in new code.
    <DllImport("Eztwain3.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="TWAIN_FreeNative")> _
    Public Shared Sub FreeNative(ByVal hdib As IntPtr)
    End Sub
    ' superceded by DIB_Free.


    ' From twain.h:
    '****************************************************************************
    '* Capabilities                                                             *
    '****************************************************************************

    Friend Const CAP_CUSTOMBASE As Int32 = &H8000

    ' all data sources are REQUIRED to support these caps 
    Friend Const CAP_XFERCOUNT As Int32 = &H1

    ' image data sources are REQUIRED to support these caps 
    Friend Const ICAP_COMPRESSION As Int32 = &H100
    Friend Const ICAP_PIXELTYPE As Int32 = &H101
    Friend Const ICAP_UNITS As Int32 = &H102
    Friend Const ICAP_XFERMECH As Int32 = &H103

    ' all data sources MAY support these caps 
    Friend Const CAP_AUTHOR As Int32 = &H1000
    Friend Const CAP_CAPTION As Int32 = &H1001
    Friend Const CAP_FEEDERENABLED As Int32 = &H1002
    Friend Const CAP_FEEDERLOADED As Int32 = &H1003
    Friend Const CAP_TIMEDATE As Int32 = &H1004
    Friend Const CAP_SUPPORTEDCAPS As Int32 = &H1005
    Friend Const CAP_EXTENDEDCAPS As Int32 = &H1006
    Friend Const CAP_AUTOFEED As Int32 = &H1007
    Friend Const CAP_CLEARPAGE As Int32 = &H1008
    Friend Const CAP_FEEDPAGE As Int32 = &H1009
    Friend Const CAP_REWINDPAGE As Int32 = &H100A
    Friend Const CAP_INDICATORS As Int32 = &H100B
    Friend Const CAP_SUPPORTEDCAPSEXT As Int32 = &H100C
    Friend Const CAP_PAPERDETECTABLE As Int32 = &H100D
    Friend Const CAP_UICONTROLLABLE As Int32 = &H100E
    Friend Const CAP_DEVICEONLINE As Int32 = &H100F
    Friend Const CAP_AUTOSCAN As Int32 = &H1010
    Friend Const CAP_THUMBNAILSENABLED As Int32 = &H1011
    Friend Const CAP_DUPLEX As Int32 = &H1012
    Friend Const CAP_DUPLEXENABLED As Int32 = &H1013
    Friend Const CAP_ENABLEDSUIONLY As Int32 = &H1014
    Friend Const CAP_CUSTOMDSDATA As Int32 = &H1015
    Friend Const CAP_ENDORSER As Int32 = &H1016
    Friend Const CAP_JOBCONTROL As Int32 = &H1017
    Friend Const CAP_ALARMS As Int32 = &H1018
    Friend Const CAP_ALARMVOLUME As Int32 = &H1019
    Friend Const CAP_AUTOMATICCAPTURE As Int32 = &H101A
    Friend Const CAP_TIMEBEFOREFIRSTCAPTURE As Int32 = &H101B
    Friend Const CAP_TIMEBETWEENCAPTURES As Int32 = &H101C
    Friend Const CAP_CLEARBUFFERS As Int32 = &H101D
    Friend Const CAP_MAXBATCHBUFFERS As Int32 = &H101E
    Friend Const CAP_DEVICETIMEDATE As Int32 = &H101F
    Friend Const CAP_POWERSUPPLY As Int32 = &H1020
    Friend Const CAP_CAMERAPREVIEWUI As Int32 = &H1021
    Friend Const CAP_DEVICEEVENT As Int32 = &H1022
    Friend Const CAP_SERIALNUMBER As Int32 = &H1024
    Friend Const CAP_PRINTER As Int32 = &H1026
    Friend Const CAP_PRINTERENABLED As Int32 = &H1027
    Friend Const CAP_PRINTERINDEX As Int32 = &H1028
    Friend Const CAP_PRINTERMODE As Int32 = &H1029
    Friend Const CAP_PRINTERSTRING As Int32 = &H102A
    Friend Const CAP_PRINTERSUFFIX As Int32 = &H102B
    Friend Const CAP_LANGUAGE As Int32 = &H102C
    Friend Const CAP_FEEDERALIGNMENT As Int32 = &H102D
    Friend Const CAP_FEEDERORDER As Int32 = &H102E
    Friend Const CAP_REACQUIREALLOWED As Int32 = &H1030
    Friend Const CAP_BATTERYMINUTES As Int32 = &H1032
    Friend Const CAP_BATTERYPERCENTAGE As Int32 = &H1033

    ' image data sources MAY support these caps 
    Friend Const ICAP_AUTOBRIGHT As Int32 = &H1100
    Friend Const ICAP_BRIGHTNESS As Int32 = &H1101
    Friend Const ICAP_CONTRAST As Int32 = &H1103
    Friend Const ICAP_CUSTHALFTONE As Int32 = &H1104
    Friend Const ICAP_EXPOSURETIME As Int32 = &H1105
    Friend Const ICAP_FILTER As Int32 = &H1106
    Friend Const ICAP_FLASHUSED As Int32 = &H1107
    Friend Const ICAP_GAMMA As Int32 = &H1108
    Friend Const ICAP_HALFTONES As Int32 = &H1109
    Friend Const ICAP_HIGHLIGHT As Int32 = &H110A
    Friend Const ICAP_IMAGEFILEFORMAT As Int32 = &H110C
    Friend Const ICAP_LAMPSTATE As Int32 = &H110D
    Friend Const ICAP_LIGHTSOURCE As Int32 = &H110E
    Friend Const ICAP_ORIENTATION As Int32 = &H1110
    Friend Const ICAP_PHYSICALWIDTH As Int32 = &H1111
    Friend Const ICAP_PHYSICALHEIGHT As Int32 = &H1112
    Friend Const ICAP_SHADOW As Int32 = &H1113
    Friend Const ICAP_FRAMES As Int32 = &H1114
    Friend Const ICAP_XNATIVERESOLUTION As Int32 = &H1116
    Friend Const ICAP_YNATIVERESOLUTION As Int32 = &H1117
    Friend Const ICAP_XRESOLUTION As Int32 = &H1118
    Friend Const ICAP_YRESOLUTION As Int32 = &H1119
    Friend Const ICAP_MAXFRAMES As Int32 = &H111A
    Friend Const ICAP_TILES As Int32 = &H111B
    Friend Const ICAP_BITORDER As Int32 = &H111C
    Friend Const ICAP_CCITTKFACTOR As Int32 = &H111D
    Friend Const ICAP_LIGHTPATH As Int32 = &H111E
    Friend Const ICAP_PIXELFLAVOR As Int32 = &H111F
    Friend Const ICAP_PLANARCHUNKY As Int32 = &H1120
    Friend Const ICAP_ROTATION As Int32 = &H1121
    Friend Const ICAP_SUPPORTEDSIZES As Int32 = &H1122
    Friend Const ICAP_THRESHOLD As Int32 = &H1123
    Friend Const ICAP_XSCALING As Int32 = &H1124
    Friend Const ICAP_YSCALING As Int32 = &H1125
    Friend Const ICAP_BITORDERCODES As Int32 = &H1126
    Friend Const ICAP_PIXELFLAVORCODES As Int32 = &H1127
    Friend Const ICAP_JPEGPIXELTYPE As Int32 = &H1128
    Friend Const ICAP_TIMEFILL As Int32 = &H112A
    Friend Const ICAP_BITDEPTH As Int32 = &H112B
    Friend Const ICAP_BITDEPTHREDUCTION As Int32 = &H112C
    Friend Const ICAP_UNDEFINEDIMAGESIZE As Int32 = &H112D
    Friend Const ICAP_IMAGEDATASET As Int32 = &H112E
    Friend Const ICAP_EXTIMAGEINFO As Int32 = &H112F
    Friend Const ICAP_MINIMUMHEIGHT As Int32 = &H1130
    Friend Const ICAP_MINIMUMWIDTH As Int32 = &H1131
    Friend Const ICAP_FLIPROTATION As Int32 = &H1136
    Friend Const ICAP_BARCODEDETECTIONENABLED As Int32 = &H1137
    Friend Const ICAP_SUPPORTEDBARCODETYPES As Int32 = &H1138
    Friend Const ICAP_BARCODEMAXSEARCHPRIORITIES As Int32 = &H1139
    Friend Const ICAP_BARCODESEARCHPRIORITIES As Int32 = &H113A
    Friend Const ICAP_BARCODESEARCHMODE As Int32 = &H113B
    Friend Const ICAP_BARCODEMAXRETRIES As Int32 = &H113C
    Friend Const ICAP_BARCODETIMEOUT As Int32 = &H113D
    Friend Const ICAP_ZOOMFACTOR As Int32 = &H113E
    Friend Const ICAP_PATCHCODEDETECTIONENABLED As Int32 = &H113F
    Friend Const ICAP_SUPPORTEDPATCHCODETYPES As Int32 = &H1140
    Friend Const ICAP_PATCHCODEMAXSEARCHPRIORITIES As Int32 = &H1141
    Friend Const ICAP_PATCHCODESEARCHPRIORITIES As Int32 = &H1142
    Friend Const ICAP_PATCHCODESEARCHMODE As Int32 = &H1143
    Friend Const ICAP_PATCHCODEMAXRETRIES As Int32 = &H1144
    Friend Const ICAP_PATCHCODETIMEOUT As Int32 = &H1145
    Friend Const ICAP_FLASHUSED2 As Int32 = &H1146
    Friend Const ICAP_IMAGEFILTER As Int32 = &H1147
    Friend Const ICAP_NOISEFILTER As Int32 = &H1148
    Friend Const ICAP_OVERSCAN As Int32 = &H1149
    Friend Const ICAP_AUTOMATICBORDERDETECTION As Int32 = &H1150
    Friend Const ICAP_AUTOMATICDESKEW As Int32 = &H1151
    Friend Const ICAP_AUTOMATICROTATE As Int32 = &H1152
    Friend Const ICAP_JPEGQUALITY As Int32 = &H1153

    ' Container and Extended Info item types:
    Friend Const TWTY_INT8 As Int32 = &H0
    Friend Const TWTY_INT16 As Int32 = &H1
    Friend Const TWTY_INT32 As Int32 = &H2
    Friend Const TWTY_UINT8 As Int32 = &H3
    Friend Const TWTY_UINT16 As Int32 = &H4
    Friend Const TWTY_UINT32 As Int32 = &H5
    Friend Const TWTY_BOOL As Int32 = &H6
    Friend Const TWTY_FIX32 As Int32 = &H7
    Friend Const TWTY_FRAME As Int32 = &H8
    Friend Const TWTY_STR32 As Int32 = &H9
    Friend Const TWTY_STR64 As Int32 = &HA
    Friend Const TWTY_STR128 As Int32 = &HB
    Friend Const TWTY_STR255 As Int32 = &HC
    Friend Const TWTY_STR1024 As Int32 = &HD
    Friend Const TWTY_UNI512 As Int32 = &HE



    ' EZTwain History: See History.txt

End Class
