## LogicGatesApp

# Overview
LogicGatesApp is a command-line application built in C# that simulates digital logic gates operations based on input files. It allows loading logic gates configurations, resolving register values, and performing various logic operations like AND, OR, NOT, etc.

# Features
Load Logic Gates: Reads logic gates configurations from a specified input file.
Resolve Register Values: Processes register values based on the loaded configurations.
Perform Logic Operations: Supports operations such as AND, OR, NOT, NAND, NOR, XOR, XNOR.
Output Results: Displays the computed results of logic gate operations.

# Installation
To run the LogicGatesApp, ensure you have the following:
- .NET Core SDK installed on your machine. You can download it from dot.net.

# Usage
1. Clone the Repository:
git clone https://github.com/Akos24/LogicGatesApp.git

2. Navigate to the Project Directory:
cd LogicGatesApp

3. Build the Application:
dotnet build

4. Run the Application:
dotnet run --project LogicGatesApp

5. Expected Input File Format:
The application expects an input file ("input.txt" by default) with the following format:
NOT AND C OR A NOT B
C 0205094150
B 0001020304
A 0028033517

# How it works
The application converts the voltage signals assigned to the registers into digital signals.
If the signal is between 0 V and 0.8 V the digital value is 0, if it's between 2.7 V and 5 V the digital value is 0. Othrwise the digital value is 'E' as error
C -> 0.2, 0.5, 0.9, 4.1, 5.0 -> 00E11
B -> 0.0, 0.1, 0.2, 0.3, 0.4 -> 00000
A -> 0.0, 2.8, 0.3, 3.5, 1.7 -> 0101E
=> NOT AND 00E11 OR 0101E NOT 00000

The gates solve the expression based on the logic of logic gates.
=> NOT AND 00E11 OR 0101E 11111
=> NOT AND 00E11 1111E
=> NOT 00E1E
=> 11E0E

# Contributing
Contributions are welcome! If you have suggestions, feature requests, or want to report issues, please create an issue or submit a pull request.

# License
This project is licensed under the MIT License - see the LICENSE file for details.
