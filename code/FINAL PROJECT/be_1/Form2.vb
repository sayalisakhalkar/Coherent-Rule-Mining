Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.IO
Imports System.Math
Imports System.String
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException
Imports System.Data.SqlClient.SqlError
Imports System.Runtime.InteropServices
Imports System.ArgumentException


Public Class Form2
    Inherits System.Windows.Forms.Form
    Dim arr6(10000) As String
    Dim posx As Integer
    Dim pc As Integer
    Dim arr5(100) As String
    Dim cc As Integer
    Dim posy As Integer
    Public Shared connection As SqlConnection
    Dim init As Integer
    Dim powset As Integer
    Dim p As Integer
    Dim f2 As Integer
    Dim f1 As Integer
    Dim pow1() As String
    Dim p1 As Integer
    Dim p2 As Integer
    Dim coh As String
    Dim flagclass As Boolean


    Public Shared coher(10000)() As String


    Dim pp As Integer
    Dim pa As Integer
    Dim ap As Integer
    Dim aa As Integer
    Dim pp1 As Integer
    Dim pa1 As Integer
    Dim ap1 As Integer
    Dim aa1 As Integer
    Dim q1 As Integer
    Dim grpbox1(100) As System.Windows.Forms.GroupBox
    Public Shared radio_selected(10000) As String
    Dim i As Integer
    Dim j As Integer
    Dim sCommand As SqlCommand
    Dim dr As SqlDataReader
    Dim k As Integer
    Dim radio_button() As System.Windows.Forms.CheckBox
    Dim countrad As Integer
    Dim checkBox(10000) As CheckBox
    Dim fc As Boolean





    Private Sub MyCheckboxes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        countrad = 0
        fc = True

        Dim p As Integer
        p = 0
        Dim i1 As Integer
        i1 = 0
        Dim s As String
        s = ""



        While (p < Form1.radio_total)

            If radio_button(p).Checked = True Then

                radio_selected(i1) = radio_button(p).Text
                'MsgBox(radio_button(p).Text + " value of p " + p.ToString)
                s = s + radio_selected(i1) + ","
                '  MsgBox(s)
                i1 += 1
                countrad += 1


            End If

            p = p + 1
        End While
        'MsgBox("Value of cc " + Form1.radio_total.ToString)




    End Sub

    Public Sub chckarray(ByVal ParamArray arr5() As String)


        Dim x As Integer

        Dim q As Integer

        Dim dum As Integer
        dum = posx
        '   posx = 300
        ' posy += 50

        x = 0
        ' MsgBox("In ckhbox " + q1.ToString)
        For q = 0 To q1 - 1

            checkBox(q) = New CheckBox()
            Me.Controls.Add(checkBox(q))
            checkBox(q).Location = New Point(posx, posy)
            checkBox(q).Text = arr5(q)
            'MsgBox(arr5(q))
            checkBox(q).Checked = True
            checkBox(q).Size = New Size(85, 30)
            checkBox(q).AutoSize = True
            AddHandler checkBox(q).CheckedChanged, AddressOf MyCheckboxes_CheckedChanged2
            posx += checkBox(q).Width
            x += 1
            If (x > 5) Then
                posy += checkBox(q).Height
                posx = dum
                x = 0
            End If

        Next




    End Sub


    Private Sub MyCheckboxes_CheckedChanged2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        flagclass = True


        Dim append As String
        append = ""
        cc = 0
        pc = 0
        '   MsgBox(q1.ToString)
        While (pc < q1)

            If checkBox(pc).Checked = True Then

                arr6(cc) = checkBox(pc).Text
                append = append + arr6(cc) + ","
                'MsgBox(arr6(cc))

                cc = cc + 1

            End If
            pc = pc + 1
        End While

        '  MsgBox("Value of cc " + cc.ToString)
        '   MsgBox(append)



    End Sub




    Private Sub rad_ck(ByVal ParamArray radio_selected() As String)
        '        MsgBox(Form1.radio_total.ToString + " q1 in form2")
        If Not fc Then
            For q = 0 To Form1.radio_total - 1
                radio_selected(q) = Form1.radio(q)
                'MsgBox(radio_selected(q))


            Next
        End If

       
       

        ''''''''''''''''''''''''''''''''''''''''''''''


        Dim sql1 As String

        q1 = 0

        sql1 = "select distinct (" + Form1.arr5(Form1.num_of_cols) + ") from " & Form1.tablename & ""
        ' MsgBox(sql1)
        Form1.sql_execute(sql1, Form1.tablename)
        sCommand = New SqlCommand(sql1, Form1.connection)
        Try

            dr = sCommand.ExecuteReader()
        Catch ex As Exception
        End Try
        ' MsgBox(dr.Read().ToString)

        ' MsgBox("dr.get")
        While dr.Read()
            arr5(q1) = dr.GetValue(0).ToString
            ' MsgBox("arr_distinct " + arr5(q1))
            q1 += 1

        End While


        '   MsgBox(arr6(q1))


        dr.Close()

        chckarray(arr5)

    End Sub

    Friend Sub power(ByVal count As Integer, ByVal ParamArray radio_selected1() As String)



        f1 = 0
        ' i = 1
        powset = 1

        ' MsgBox("i " + i.ToString)

        While (f1 < i)
            powset = powset * 2
            f1 = f1 + 1
        End While


        Dim pow(powset) As String
        ReDim pow1(powset)

        p = 0
        'Size of this array will be number of elements in power set
        Dim arr2(powset) As String
        ' Finding powersets in the form 0 till 15 -- various combinations --> 0000, 0001 ,.......,1111

        f2 = 0
        While (f2 < powset)

            ' Converting to Binary ..if not of length 4 then pad that many zero's at the starting
            arr2(p) = Convert.ToString(f2, 2).PadLeft(i, "0"c)
            ' MsgBox(arr2(p))
            p = p + 1
            f2 = f2 + 1

        End While
        Dim Str As String

        Dim qq As Integer
        qq = 0
        Dim qq1 As Integer
        qq1 = 0
        While (qq < powset)
            Str = ""
            qq1 = 0
            While (qq1 < i)
                ' MsgBox("arr2(qq).Chars(qq1)" + arr2(qq).Chars(qq1))
                If (arr2(qq).Chars(qq1) = "1") Then

                    Str = Str + radio_selected(qq1) + ","
                    'MsgBox("rs" + radio_selected(qq1))
                End If
                qq1 += 1
            End While
            pow(qq) = Str
            pow1(qq) = Str
            '  MsgBox(pow1(qq))

            qq += 1
        End While



        ' MsgBox(pow1(qq - 1))



        Dim tp1 As Integer
        tp1 = 1

        While tp1 < powset
            'MsgBox(pow1(tp1) + " b4 ")

            pow1(tp1) = pow1(tp1).Remove(pow1(tp1).LastIndexOf(","), 1)
            ' MsgBox(" aftre " + pow1(tp1))
            tp1 += 1

        End While

    End Sub




    Public Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fc = False
        flagclass = False


        ReDim radio_button(Form1.radio_total)
        Dim name As String
        name = ""
        Dim m(Form1.cc) As Integer
        Dim mx(Form1.cc) As Integer


        Dim f1 As Form1
        f1 = New Form1()



        init = 0
        i = 0
        j = 0
        k = 0

        posx = 5
        posy = 45

        Dim dis As Integer
        Dim tp As Integer
        tp = 0

        Dim x As Integer
        x = 15
        Dim y As Integer
        y = 15

        dis = 0
        Dim l As Integer
        l = Form1.arr6.Length
        ' MsgBox(l.ToString)
        While (i < Form1.cc)

            init = Form1.arr_distinct(i)

            grpbox1(i) = New GroupBox
            grpbox1(i).Location = New System.Drawing.Point(posx, posy)
            '  grpbox1(i).Name = Form1.arr6(i) + "hello"
            grpbox1(i).Text = Form1.arr6(i)
            ' grpbox1(i).AutoSize = True


            grpbox1(i).AutoSize = True



            '  grpbox1(i).Size = New System.Drawing.Size(300, 80)
            grpbox1(i).TabIndex = 0
            grpbox1(i).TabStop = False

            Me.Controls.Add(grpbox1(i))
            m(i) = posx
            mx(i) = posy

            grpbox1(i).ResumeLayout(False)
            grpbox1(i).PerformLayout()

            If (init > 2) Then

                While (init > 0)



                    radio_button(k) = New CheckBox
                    'radio_button(k).AutoSize = True

                    radio_button(k).Location = New System.Drawing.Point(x, y)
                    'radio_button(k).Name = Form1.radio(k)
                    radio_button(k).Text = Form1.radio(k)
                    radio_button(k).Checked = True



                    radio_button(k).Size = New System.Drawing.Size(90, 17)
                    radio_button(k).TabIndex = 0
                    radio_button(k).TabStop = True



                    radio_button(k).UseVisualStyleBackColor = True
                    grpbox1(i).Controls.Add(radio_button(k))


                    AddHandler radio_button(k).CheckedChanged, AddressOf MyCheckboxes_CheckedChanged
                    x += radio_button(k).Width
                    '  x += 70



                    If (x > 280) Then
                        y += radio_button(k).Height
                        'y += 20
                        tp = 0
                        x = 15


                    End If
                    tp += 1
                    k = k + 1
                    init -= 1

                End While

            Else
                While (init > 0)



                    radio_button(k) = New CheckBox
                    '  radio_button(k).AutoSize = True

                    radio_button(k).Location = New System.Drawing.Point(x, y)
                    'radio_button(k).Name = Form1.radio(k)
                    radio_button(k).Text = Form1.radio(k)
                    radio_button(k).Enabled = True
                    radio_button(k).Checked = True



                    radio_button(k).Size = New System.Drawing.Size(90, 17)
                    radio_button(k).TabIndex = 0
                    radio_button(k).TabStop = True

                    radio_button(k).UseVisualStyleBackColor = True
                    grpbox1(i).Controls.Add(radio_button(k))

                    '  MsgBox(radio_button(k).Text)

                    AddHandler radio_button(k).CheckedChanged, AddressOf MyCheckboxes_CheckedChanged
                    x += radio_button(k).Width
                    k = k + 1
                    init -= 1

                End While
            End If
            j += 1
            posx += grpbox1(i).Width



            If (j > 2) Then
                j = 0
                posy += grpbox1(i).Height

                posx = 0
            End If
            i = i + 1

            x = 15
            y = 15


        End While
        '  MsgBox("x " + posx.ToString + " y " + posy.ToString)

        'MsgBox(k.ToString)

        rad_ck(radio_selected)

        '
        'Form2
        '
        Me.ClientSize = New System.Drawing.Size(416, 436)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)


        posx = m.Max() + 15
        posy = mx.Max() + 15





    End Sub
    Friend WithEvents grpbox As System.Windows.Forms.GroupBox
    'Friend WithEvents radio_button As System.Windows.Forms.RadioButton
    ' Friend WithEvents RadioButton1 As     System.Windows.Forms.RadioButton

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sCommand55k As New SqlCommand
       ' MsgBox("ar6 " + arr6(0))
        Dim connectionString As String
        connectionString = "Data Source=ARTI;Initial Catalog=beproject;Integrated Security=true;"
        connection = New SqlConnection(connectionString)
        Dim sqleee As String
        sqleee = "delete from coherent1"
        ' MsgBox(sqlee)
        connection.Open()
        sCommand = New SqlCommand(sqleee, connection)
        Try
            sCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message + " Error")
        End Try
        connection.Close()

        Dim i2 As Integer
        i2 = 0
        Dim ppp As Integer
        ppp = 0
        Dim ppp1 As Integer
        ppp1 = 0
        Dim ppp2 As Integer
        ppp2 = 0
        Dim ppp3 As Integer
        ppp3 = 0
        power(i - 1, radio_selected)
        'MsgBox(pow1(2))
        pp = 0
        pa = 0
        ap = 0
        aa = 0
        pp1 = 0
        aa1 = 0
        ap1 = 0
        Dim temp_chkk As String
        temp_chkk = ""
        Dim temp_chkk1 As String
        temp_chkk1 = ""
        pa1 = 0
        Dim ind1 As Integer
        Dim ind2 As Integer
        Dim flgg As Boolean
        Dim indexxx As Integer
        indexxx = 0
        flgg = False
        Dim ind3 As Integer
        Dim flg As Boolean
        flg = False
        Dim flg1 As Boolean
        flg1 = False
        ind1 = 0
        ind2 = 1
        ind3 = 0
        Dim u As Integer
        u = 0
        Dim support_class As Integer
        support_class = 0
        Dim pp2 As Double
        pp2 = 0.0
        pc = cc
        '  MsgBox("pc " + pc.ToString)

        '  MsgBox(powset.ToString)

        coh = ""

        While (ind1 < pc)
            ind2 = 1

            While (ind2 < powset)

                ind3 = 0
                pp = 0
                aa = 0
                ap = 0
                pa = 0
                pp1 = 0
                aa1 = 0
                ap1 = 0
                pa1 = 0
                pp2 = 0
                ppp = 0
                ppp1 = 0
                ppp2 = 0
                ppp3 = 0
                ' MsgBox("pow1(ind2)" + pow1(ind2))
                flgg = False
                ' MsgBox(pow1(ind2).Contains(",").ToString)
                If (pow1(ind2).Contains(",")) Then
                    flgg = True
                    indexxx = pow1(ind2).IndexOf(",")
                    ' MsgBox("pow(ind2) " + pow1(ind2) + "indexxx " + indexxx.ToString + "pow1(ind2).Length - 1 " + (pow1(ind2).Length - 1).ToString)
                    'MsgBox("DISP " + pow1(ind2) + ".Substring(" + (indexxx + 1).ToString + "," + (pow1(ind2).Length - 1).ToString + ")")
                    'indexxx + 1, pow1(ind2).Length +1
                    'MsgBox("pow " + pow1(ind2))
                    temp_chkk = (pow1(ind2)).Substring(indexxx + 1)
                    ' MsgBox("temp_chkk " + temp_chkk)
                    temp_chkk1 = (pow1(ind2)).Substring(0, indexxx)
                    ' MsgBox("temp_chkk1 " + temp_chkk1)
                Else
                    flgg = False
                End If
                While (ind3 < Form1.total1)

                    If (comp(pow1(ind2), Form1.csv(ind3))) Then

                        pp1 += 1

                    End If
                    If (flgg = True) Then
                        If (comp(temp_chkk, Form1.csv(ind3))) Then

                            ppp += 1

                        End If
                        If (comp(temp_chkk1, Form1.csv(ind3))) Then

                            ppp3 += 1

                        End If
                    End If

                    
                    ind3 = ind3 + 1
                End While
                ind3 = 0
                While (ind3 < Form1.total1)

                    If (Form1.csv(ind3).Contains(arr6(ind1))) Then
                        pp2 += 1
                        If (flgg = True) Then
                            If (comp(temp_chkk, Form1.csv(ind3))) Then

                                ppp1 += 1

                            End If
                            If (comp(temp_chkk1, Form1.csv(ind3))) Then

                                ppp2 += 1

                            End If
                        End If
                        If (comp(pow1(ind2), Form1.csv(ind3))) Then

                            flg = True
                            pp += 1
                        Else

                            pa += 1
                        End If
                    Else

                        If (flg) Then
                            ap += 1
                            flg = False
                        Else
                            aa += 1
                        End If
                    End If
                    ind3 = ind3 + 1
                End While
                Dim support As String
                support = ""
                Dim sqlee As String
                Dim confidence As Integer
                confidence = 0
                Dim lift1 As Double
                lift1 = 0.0
                Dim liftAA As Double
                liftAA = 0.0
                Dim liftBB As Double
                liftBB = 0.0
                Dim IruleA As Double
                IruleA = 0.0
                Dim IruleB As Double
                IruleB = 0.0
                Dim ind11 As Integer
                ind11 = 0
                Dim confid As Integer
                confid = 0
                Dim confid1 As Integer
                confid1 = 0
                Dim lift2 As Integer
                lift2 = 0
                Dim lift3 As Integer
                lift3 = 0
                ' ind11 = pow1(ind2).IndexOf(",")
                'MsgBox("ind11 " + ind11.ToString)
                'MsgBox("pp1" + pp1.ToString + "pp " + pp.ToString + " ap" + ap.ToString + " aa" + aa.ToString + " pa" + pa.ToString)

                If pp > ap And pp > pa Then
                    If aa > ap And aa > pa Then

                        If pow1(ind2).Last.Equals(",") Then
                            pow1(ind2) = pow1(ind2).Remove(pow1(ind2).LastIndexOf(","), 1)
                        End If
                        confidence = (pp / pp1) * 100

                        '    MsgBox("Confidence " + confidence.ToString)
                        support = pp.ToString + "/" + Form1.total1.ToString
                        lift1 = (confidence / pp2)
                        If (flgg = True) Then
                            confid = (ppp1 / ppp) * 100
                            confid1 = (ppp2 / ppp3) * 100
                            lift2 = (confid / pp2)
                            lift3 = (confid1 / pp2)
                            liftAA = (lift1 / lift2)
                            liftBB = (lift1 / lift3)
                            IruleA = (liftAA / lift3)
                            IruleB = (liftBB / lift2)
                        End If
                        coh += " " + pow1(ind2) + " --> " + arr6(ind1) + ";" + ""

                        sqlee = "insert into coherent1 values('" + pow1(ind2) + "-->" + arr6(ind1) + "','" + support.ToString + "','" + confidence.ToString + "','" + lift1.ToString + "','" + liftAA.ToString + "','" + liftBB.ToString + "','" + IruleA.ToString + "','" + IruleB.ToString + "')"
                        ' MsgBox("sqlee " + sqlee)
                        'MsgBox(sqlee)
                        connection.Open()
                        sCommand55k = New SqlCommand(sqlee, connection)
                        Try
                            sCommand55k.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message + " Error")
                        End Try
                        ' MsgBox(" arr6() " + arr6(ind1))
                        ' MsgBox("pp - both present " + pp.ToString + "pp1 only left side present " + pp1.ToString)

                        ' MsgBox("support " + support.ToString + "total " + Form1.total1.ToString)
                        u = u + 1
                    End If
                End If
                ind2 += 1
                connection.Close()
            End While
            ind1 += 1
            connection.Close()
        End While


        '  coh = coh.Remove(coh.LastIndexOf(","), 1)
        'MsgBox(coh)

        TextBox1.Text = coh

        MsgBox("total no of coherent rules are as follows" + u.ToString)
        Form3.Show()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub



    Private Function comp(ByRef subs As String, ByRef str As String)
        Dim flag As Boolean
        Dim s(100) As String
        Dim ind As Integer
        ind = 0
        'subs = "hairT,feathersF,eggsT"
        'MsgBox("str " + str)

        Dim ch As Char

        ch = subs.Last


        Dim k As Integer
        k = 0
        ' MsgBox(" str " + str)
        ' MsgBox(" subs1 " + subs)
        If (ch.Equals(",")) Then

            subs = subs.Remove(subs.LastIndexOf(","), 1)
        End If

        ' MsgBox(" subs2 " + subs)
        s = subs.Split(",")
        ' MsgBox("s len " + s.Length.ToString)
        flag = True
        Dim if123 As Integer
        if123 = 0
        'MsgBox("s " + s.Length.ToString)
        While ind < s.Length
            ' MsgBox("contains " + str.Contains(s(ind)).ToString)
            ' MsgBox(" s== " + s(ind))

            If str.Contains(s(ind)) Then
                'MsgBox(" ind " + ind.ToString)

            Else
                Return False
            End If
            ind += 1
        End While



        Return flag


    End Function
End Class