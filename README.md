ChatLad: A WPF Chatbot with Old English Flair

Overview

ChatLad is a WPF-based chatbot application that integrates with the Google Gemini API (or other similar chatbot APIs) to provide interactive conversations. The chatbot is designed to respond in Old English while offering a user-friendly graphical interface.

Features

Interactive Chat Interface: A clean and responsive chat UI built with WPF.
Google Gemini Integration: Sends user messages to the Google Gemini API for processing and retrieves responses.
Customizable Instructions: Define the chatbot's behavior and tone, e.g., speaking in Old English.
Dynamic Textbox Resizing: The input box adjusts its size based on the user's input.
Message Styling: User and chatbot messages are visually distinct with styled borders and text.

Prerequisites

.NET Framework or .NET Core compatible development environment.
An API key for Google Gemini or another chatbot API.
Newtonsoft.Json library for JSON serialization and deserialization.

Installation

Clone the repository or copy the provided code into your development environment.
Ensure that all required NuGet packages are installed: Newtonsoft.Json
Replace YOUR_API_KEY in the CallGoogleGeminiAPI method with your valid API key.
Update the apiUrl in the same method if you use a different API or endpoint.

Usage

Start the Application: Launch the WPF application.
Enter a Message: Type a message in the input box labeled "Write to ChatLad."
On focus, the placeholder text clears.
Send the Message: Click the "Send" button to send your input to the chatbot.
View Responses: ChatLad's responses appear dynamically in the chat interface.
Key Methods and Logic

1. CallGoogleGeminiAPI

Sends a POST request to the chatbot API with the user's message.
Processes the JSON response to extract the chatbot's reply.
Handles API errors and exceptions gracefully.

2. Sendbtn_Click

Combines system instructions and the user’s message.
Calls the CallGoogleGeminiAPI method to fetch the chatbot’s response.
Displays both user input and chatbot responses in the chat interface.

3. AddMessageToChat

Styles and adds messages (user or chatbot) to the chat interface.
Distinguishes between user and chatbot messages with color and alignment.

4. Tb__TextChanged

Dynamically adjusts the height of the input textbox based on the content.

5. Tb_GotFocus

Clears the default placeholder text when the input box gains focus.

Customization

Chatbot Behavior: Modify the systemInstructions string in Sendbtn_Click to change ChatLad’s behavior and tone.
API Integration: Update the apiUrl and request structure in CallGoogleGeminiAPI for compatibility with other chatbot APIs.
UI Appearance: Customize styles and colors in the AddMessageToChat method to match your preferences.

Troubleshooting

API Key Issues: Ensure that the API key is correctly set and has valid permissions.
UI Not Responding: Verify that all required libraries are installed and the WPF application is properly configured.
Incorrect Responses: Double-check the request structure to ensure compatibility with your API.

Future Improvements

Add support for voice input and output.
Enable logging for debugging and analytics.
