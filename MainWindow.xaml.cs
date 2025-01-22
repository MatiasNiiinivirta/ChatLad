using Newtonsoft.Json;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ChatBoi
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		
		public MainWindow()
		{
			InitializeComponent();

			this.Title = "\u263aChatLad";


			if (Tb_.Text == "Write to ChatLad")
			{
				Tb_.Foreground = Brushes.Gray;
			}
			
		

		}

		private async Task<string> CallGoogleGeminiAPI(string userMessage)
		{
			using (HttpClient client = new HttpClient())
			{
				// API URL ja API-avain
				string apiKey = "YOUR_API_KEY";  // Add your API-key Here
				string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}"; //Add your URL-here. This app uses google gemini, but it could be whatever chatbot for example OpenAI.

				//This code creates an anonymous object (requestContent) that matches the expected JSON structure. This is useful when you need to construct requests where the data you send (in this case, the user's message) complies with the API's requirements. Be mindful that if you use a different Ai than google gemini, this JSON struckture could change.
				var requestContent = new
				{
					contents = new[]
					{
			new
			{
				parts = new[]
				{
					new { text = userMessage } // Users message
                }
			}
		}
				};

				string jsonContent = JsonConvert.SerializeObject(requestContent);
				HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

				try
				{
					// Sends POST-request to API
					HttpResponseMessage response = await client.PostAsync(apiUrl, httpContent);

					if (response.IsSuccessStatusCode)
					{
						string responseContent = await response.Content.ReadAsStringAsync();


						// Parse the JSON response and check if the 'candidates' field exists
						var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);


						// Check that the 'candidates' and 'content' fields are present.
						if (responseObject?.candidates != null && responseObject.candidates.Count > 0)
						{
							var candidate = responseObject.candidates[0];
							var text = candidate?.content?.parts?[0]?.text ?? "No response text found.";
							return text;
						}
						else
						{
							return "No candidates or text found in the response.";
						}
					}
					else
					{
						string responseContent = await response.Content.ReadAsStringAsync();
						return $"Error: {response.StatusCode}, Details: {responseContent}";
					}
				}
				catch (Exception ex)
				{
					return $"An error occurred: {ex.Message}";
				}
			}
		}

		private void Tb__TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			// This method makes the textbox grow according the size of the message
			var textBox = sender as System.Windows.Controls.TextBox;

		
			if (textBox != null)
			{

				double minHeight = 30;
				textBox.Height = Double.NaN;
				textBox.UpdateLayout();   
				textBox.Height = textBox.ActualHeight;

				textBox.Height = Math.Max(minHeight, textBox.ActualHeight);
			}
		}

		private void Tb_GotFocus(object sender, RoutedEventArgs e)
		{
			var textBox = sender as TextBox;

			// This method will empty the textbox from "Write to ChatLad."
			if (textBox != null && textBox.Text == "Write to ChatLad")
			{
				textBox.Text = "";
				textBox.Foreground = Brushes.Black;
			}
		}


		private async void Sendbtn_Click(object sender, RoutedEventArgs e)
		{
            //Give system instructions and define the style of your ChatBot
			string systemInstructions = "Your name is ChatLad. Do not be repetive of your name unless asked. Talk me in old British English";

			// Get user input
			string userMessage = Tb_.Text;

			string combinedMessage = $"{systemInstructions}\n\n{userMessage}";
			// Clear the text box
			Tb_.Text = string.Empty;

			// Display the user message in the chat
			AddMessageToChat("You: " + userMessage, false);

			// Get bot response from the API
			string botResponse = await CallGoogleGeminiAPI(combinedMessage);

			// Display the bot response in the chat
			AddMessageToChat("ChatLad: " + botResponse, true);

			if(string.IsNullOrWhiteSpace(Tb_.Text))
			{
				Tb_.Text = "Write to ChatLad";
				Tb_.Foreground = Brushes.Gray;
			}
		}

		private void AddMessageToChat(string message, bool isBotMessage)
		{
			// Create border element
			Border messageBorder = new Border();
			messageBorder.Margin = new Thickness(0, 5, 0, 5);
			messageBorder.Padding = new Thickness(5);

			//Set the Border color based on whether the message is from the chatbot or the user

			TextBlock botmessageText = new TextBlock
			{
				Text = message,
				Margin = new Thickness(5),
				TextWrapping = TextWrapping.Wrap, // Text wraps when the width is exeded
				FontSize = 14, 
			};

			if (isBotMessage)
			{
				messageBorder.Background = Brushes.White;
				messageBorder.BorderBrush = Brushes.White;  // Chatbots color
			}
			else
			{
				messageBorder.Background = Brushes.Blue;
				messageBorder.BorderBrush = Brushes.Blue;   // Users color
				botmessageText.Foreground = Brushes.White;
			}

			messageBorder.BorderThickness = new Thickness(2);
			messageBorder.Child = botmessageText;
			messageBorder.CornerRadius = new CornerRadius(10);

			// Add message to stackpanel
			messageBorder.Child = botmessageText;

			// Add message to stackpanel
			MessageStackPanel.Children.Add(messageBorder);
		}

	}
}