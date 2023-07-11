namespace password_generator_app_maui;

using System;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void Generate_Password(object sender, EventArgs e)
    {
		int nOfCharacters;

		//check if is a number
		bool isInt = int.TryParse(LengthField.Text, out nOfCharacters);

        PasswordField.Text = LengthField.Text;

        //if is not a number
        if (LengthField.Text == null || nOfCharacters == 0)
        {
            nOfCharacters = 13;
            RandomyzeIt(nOfCharacters);
        } else if (isInt ==  false || nOfCharacters > 24 || nOfCharacters < 1)
		{
			PasswordField.Text = "Invalid Range";
		} else
		{
			RandomyzeIt(nOfCharacters);
        }

        //function to generate the password
        void RandomyzeIt(int length)
		{
			string password = "";

			const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*{}[]()/\\'\"~,;:.<>";

			Random random = new Random();

			for(int i = 0; i < length; i++)
			{
                int rnum = random.Next(characters.Length);
                password += characters.Substring(rnum, 1);
            }

			PasswordField.Text = password;

			password = "";
        }
    }
}

