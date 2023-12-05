# C# Windows Form Application: Compiler-Project

## Overview

Welcome to the Compiler Project Windows Forms application! This program serves as a simple compiler that scans and processes code based on predefined transition rules.

## Features

- **Transition Rules:**
  - Transition rules for scanning are defined in the `transitionTable.txt` file.
  - The project includes a `transRule` list and a `MapData` method to map keyword, operator, and special character values.

- **Token Identification:**
  - The application identifies tokens based on transition rules and a state machine.
  - Token categories include keywords, identifiers, operators, literals, and special characters.

- **Token Scanner:**
  - The `Result` method scans and tokenizes input text based on the defined transition rules.
  - It categorizes tokens into different types such as Keywords, Identifiers, Operators, Numbers, Strings, and Special Characters.

## Code Snippet: Token Scanner

```csharp
public string Result(string txt, string src = @"transistionTable.txt")
{
    // ... (previous code)

    while (txtIndex != txt.Length)
    {
        // ... (previous code)

        iState = nextState(iState, cChar);
        switch (iState)
        {
            // ... (cases for different states)

            case 30:
            case 33:
                iState = 0;
                sToken = "";
                break;
        }
    }
    return result;
}
```

## How to Use

1. Run the application.
2. Enter the code inside the text area or select the "Read from file" button to open a file.
4. Press the "Scan" button to initiate the scanning process.
5. View the results of the scanning process.
6. Exit the application when you are done.

<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/3.Principles-of-Compiler-Design-Module/Compiler-Project/Screenshots/Screenshot%202023-12-05%20223546.png"/>

Feel free to explore and utilize this compiler project for scanning and processing code efficiently with this Windows Forms application!
