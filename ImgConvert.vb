''' ImageConvert - Converts to different image formats, or batch converts
''' many files into 1024*768 jpgs if you drag multiple files onto it

''' nik martin - imageconvert@nik-martin.com

'
'=========IMPORTS=========
Imports System
Imports System.drawing
Imports System.IO
Imports Microsoft.VisualBasic
==========================

Module ConvertImage
    Sub Main()
        Dim sFileToConvert As String
        'make the default a jpg, for whatever reason
        Dim sDestType As String = "JPG"
        Dim sArgs() as String
        Dim nRatio as Single
        Dim nScale as single
        Dim oSize as Size
        Dim i as integer

'Stop
        sArgs= GetCommandLineArgs()
        If (sArgs.length=1 And args(0)="") Then



         'TODO: Add prompt for size if multiple files are dragged onto
         'the app

        Console.WriteLine("Image File to Convert :")
        strFileToConvert = Console.ReadLine()

        Console.WriteLine("Type to convert to (GIF,JPG,BMP,TIF,ICO,PNG,WMF : ")
        strDestType = Console.ReadLine()
            strDestType = strDestType.ToUpper

   End If

         For i = 1 to args.length-1 step 2
         strFileToConvert = args(i)
        'Initialize the bitmap object by supplying the image file path
        Dim b As New Bitmap("" & strFileToConvert & "")
        console.writeline("H:" & b.size.height & " W:" & b.size.width)
        If b.size.height > b.size.width Then


         ratio  = b.size.width/b.size.height
         Scale = b.size.height/1024

         oSize = New Size(CInt((b.size.height/Scale)*ratio),1024)
        Else

         ratio = b.size.height/b.size.width
         Scale = b.size.width/1024

         oSize = New Size(1024,CInt((b.size.width/Scale)*ratio))
        End If
        console.writeline("SCALE: " & Scale)

        'Convert the file in GIF format, also check out other formats like JPG, TIFF

            Select Case strDestType
                Case "GIF"

                    b.Save(strFileToConvert & "." & strDestType, System.Drawing.Imaging.ImageFormat.Gif)

                Case  "", "JPG"

                  b=new BitMap(b,oSize)
                  b.Save(strFileToConvert & "." & strDestType, System.Drawing.Imaging.ImageFormat.Jpeg)

                Case "BMP"

                    b.Save(strFileToConvert & "." & strDestType, System.Drawing.Imaging.ImageFormat.Bmp)

                Case "TIF"

                    b.Save(strFileToConvert & "." & strDestType, System.Drawing.Imaging.ImageFormat.Tiff)

                Case "ICO"

                    b.Save(strFileToConvert & "." & strDestType, System.Drawing.Imaging.ImageFormat.Icon)

                Case "PNG"

                    b.Save(strFileToConvert & "." & strDestType, System.Drawing.Imaging.ImageFormat.Png)

                Case "WMF"

                    b.Save(strFileToConvert & "." & strDestType, System.Drawing.Imaging.ImageFormat.Wmf)
            'Case Else

            'b.Save(strFileToConvert & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)


            End Select
            console.WriteLine("Sucessfully Converted to " & strFileToConvert & "." & strDestType)
        Next i



        'Catch e As Exception
        '    Console.WriteLine("Had a problem converting to " & strFileToConvert & "." & strDestType)
        '    Console.WriteLine("Check your file names and paths and try again")
        'End Try
    End Sub


    Function GetCommandLineArgs() As String()
      ' Declare variables.
      Dim separators As String = Chr(34)
      Dim commands As String = Microsoft.VisualBasic.Command()
      console.writeline(Commands)
      Dim args() As String = commands.Split(separators.ToCharArray)
      Return args
   End Function

End Module
