ChatLad: An API based Chatbot with Old English Flair

Overview

ChatLad is a WPF-based chatbot application that integrates with the Google Gemini API (or other similar chatbot APIs) to facilitate interactive conversations. Designed with a user-friendly graphical interface, the chatbot responds in Old English for a fun and unique experience. While the Old English is a playful feature, the core functionality of the app is to provide an interface for customer service purposes. The language style can easily be adjusted or removed to suit real-world applications.

Features

Interactive Chat Interface: A clean and responsive chat UI built with WPF.
Google Gemini Integration: Sends user messages to the Google Gemini API for processing and retrieves responses.
Dynamic Textbox Resizing: The input box adjusts its size based on the user's input.
Message Styling: User and chatbot messages are visually distinct with styled borders and text.

Prerequisites

.NET Framework or .NET Core compatible development environment.
An API key for Google Gemini or another chatbot API.

![CHATBOI](https://github.com/user-attachments/assets/5bcc1e26-a590-4a49-a288-fbdfccb0271b)

![ChatboiCode](https://github.com/user-attachments/assets/48915782-8e3a-49cd-bdea-7373e47dc492)

Usage:

-.Download the project and open the sln. in your visual studio. 
- Generate an API key Google Gemini or another chatbot API. ( in case of gemini for example here: https://aistudio.google.com/prompts/new_chat)
- Navigate into MainWindow.cs and copy you API key here:
 
![APIkey](https://github.com/user-attachments/assets/3aba059a-e2e9-4077-b14d-180f42ef8a6c)

BONUS
- You can change the response style of the chatbot here by describing your instructions into systemInstructions

  ![chatboiPromt](https://github.com/user-attachments/assets/2e8166f4-5561-4753-8b1e-6f6e092d7318)

- You can modify the chatbot for customer service

  ![Customerserver](https://github.com/user-attachments/assets/469717c8-4cbc-4761-b233-fd8e9fadf4d1)


- OR you can even modify the chatbot to talk like ghetto! or whatever you want 

  
![ghetto](https://github.com/user-attachments/assets/e5b44e04-9371-4e5c-ad72-76a0132d9060)

  

HOW TO RUN
- Download the ZIP file from GitHub.

- Extract the contents of the ZIP file.

- open visual studio

- Choose: Open a folder or a solution

- Navigate to the extracted file and choose .csproj file

- This should open the project in visual studio and create a sln. file

- Navigate to MainWindow and paste your API-key

- Run the program

.


