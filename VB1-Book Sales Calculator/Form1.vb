' ******************************************************************************
' *                               VB2-Calculator                               *
' ******************************************************************************
' *                                                                            *
' *  Programmer   : Max  Del RIo                                               *
' *  Chapter      : VB2                                                        *
' *  Assignment   : ASSN#2                                                     *
' *  Form Name    : VB2-Calculator                                             *
' *  Date Created : 11/10/2016                                                 *
' *  Description  : This form calculates a sales discount, sales tax, and      *
' *                 total due.                                                 *
' *                                                                            *
' ******************************************************************************

' Set Define Variables Option On
Option Explicit On

' Set No Automatic Data Conversion On
Option Strict On


Public Class Form1
    ' Set Sales Limit constant = $500
    Const SALES_LIMIT_Integer As Integer = 500

    ' Set Double Discount Limit constant = $300
    Const DOUBLE_DISCOUNT_LIMIT_Integer As Integer = 300

    ' Sete Sales Tax Percent constant = 8.75%
    Const SALES_TAX_PERCENT_Decimal As Decimal = 0.0875D

    ' Set Minimum Discount Percent constant = 10%
    Const MINIMUM_DISCOUNT_PERCENT_Decimal As Decimal = 0.1D

    ' Set Maximum Discount Percent constant = 15%
    Const MAXIMUM_DISCOUNT_PERCENT_Decimal As Decimal = 0.15D

    ' Set Special Discount Percent constant = 20%
    Const SPECIAL_DISCOUNT_PERCENT_Decimal As Decimal = 0.2D

    Private Sub calculateButton_Click(sender As Object, e As EventArgs) Handles calculateButton.Click
        ' **************************************************************************
        ' *  Procedure    : Calculate-Click                                        *
        ' *  Description  : The Calculate button determines, calculates, and       *
        ' *                 displays the Percent, Discount, Sales Tax, and Total   *
        ' *                 Due. It displays a Face image for supervisor approval  *
        ' *                 for Sales greater than or equal to the Sales Limit.    *
        ' **************************************************************************

        ' Define Variables: Sales, Code, Percent, Discount, Sales Tax, Total Due
        Dim salesDecimal, percentDecimal, discountDecimal, salesTaxDecimal, totalDueDecimal As Decimal
        Dim codeString As String

        ' Get Sales from Form
        salesDecimal = Decimal.Parse(salesTextBox.Text)

        ' Get Code from Form
        codeString = codeComboBox.Text

        ' IF Code = "Student"
        If codeString = "Student" Then

            ' Percent = Minimum Discount Percent constant
            percentDecimal = MINIMUM_DISCOUNT_PERCENT_Decimal

            ' Else IF Code = "Falculty" Or Code = "Staff"
        ElseIf codeString = "Faculty" Or codeString = "Staff" Then

            ' Percent = Maximum Discount Percent constant
            percentDecimal = MAXIMUM_DISCOUNT_PERCENT_Decimal

            ' Else IF Code = "Special"
        ElseIf codeString = "Special" Then

            ' Percent = Special Discount Percent constant
            percentDecimal = SPECIAL_DISCOUNT_PERCENT_Decimal

            ' Else
        Else

            ' Percent = 0
            percentDecimal = 0

            ' End IF
        End If

        ' IF Sales <=Double Discount Limit constant
        If salesDecimal <= DOUBLE_DISCOUNT_LIMIT_Integer Then

            ' Calculate Discount = Sales * Percent
            discountDecimal = salesDecimal * percentDecimal

            ' Else
        Else

            ' Calculate Discount = Double Discount Limit constant * Percent + (Sales - Double Discount Limit constant) * (2 * Percent)
            discountDecimal = DOUBLE_DISCOUNT_LIMIT_Integer * percentDecimal + (salesDecimal - DOUBLE_DISCOUNT_LIMIT_Integer) * (2D * percentDecimal)

            ' End IF
        End If

        ' Calculate Sales Tax = (Sales - Discount) * Sales Tax Percent constant
        salesTaxDecimal = (salesDecimal - discountDecimal) * SALES_TAX_PERCENT_Decimal

        ' Calculate Total Due = Sales - Discount + Sales Tax
        totalDueDecimal = salesDecimal - discountDecimal + salesTaxDecimal

        ' Display Percent
        percentLabel.Text = percentDecimal.ToString("P2")

        ' Display Discount
        discountLabel.Text = discountDecimal.ToString("C2")

        ' Display Sales Tax
        salesTaxLabel.Text = salesTaxDecimal.ToString("C2")

        ' Display Total Due
        totalDueLabel.Text = totalDueDecimal.ToString("C2")

        ' IF Sales >= Sales Limit constant
        If salesDecimal >= SALES_LIMIT_Integer Then

            ' Display Face Image
            facePictureBox.Visible = True

            ' Else
        Else

            ' Hide Face Image
            facePictureBox.Visible = False
            ' End IF
        End If

        ' End Calculate-Click
    End Sub

    Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click
        ' **************************************************************************
        ' *  Procedure    : Clear-Click                                            *
        ' *  Description  : The Clear button clears the Sales, Percent, Discount,  *
        ' *                 Sales Tax, and Total Due information. It sets the Code *
        ' *                 to "None", makes the Face image invisible, and sets    *
        ' *                 the focus to the sales.                                *
        ' **************************************************************************

        ' Define Variables: None

        ' Clear Sales TextBox
        salesTaxLabel.Text = ""

        ' Set Code ComboBox to "None"
        codeComboBox.Text = "None"

        ' Clear Percent Label
        percentLabel.Text = ""

        ' Clear Discount Label
        discountLabel.Text = ""

        ' Clear Sales Tax Label
        salesTaxLabel.Text = ""

        ' Clear Total Due Label
        totalDueLabel.Text = ""

        ' Make Face Image invisible
        facePictureBox.Visible = False

        ' Set the Focus to Sales TextBox
        salesTextBox.Focus()

    End Sub

    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        ' **************************************************************************
        ' *  Procedure    : Exit-Click                                             *
        ' *  Description  : When the Exit Button is clicked the form is closed.    *
        ' **************************************************************************

        ' Define Variables: None
        ' Close the Form
        Me.Close()

    End Sub
End Class
