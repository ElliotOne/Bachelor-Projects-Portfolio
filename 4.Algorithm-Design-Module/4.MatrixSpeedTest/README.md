# Console Application: Matrix Multiplication Comparison

## Overview

This console application compares two different methods for matrix multiplication: the **simple** approach and the **Strassen** algorithm. The data, including matrix sizes and execution times, is saved in `data.txt`.

## Simple Matrix Multiplication

### Implementation
The `simple` method performs matrix multiplication in a straightforward manner. It utilizes three nested loops to iterate through the matrices and calculate the product.

### Usage
To generate data for simple matrix multiplication, the application prompts the user to provide parameters such as the starting matrix size (`from`), the ending matrix size (`to`), and the increment step (`increase`). It then measures the execution time for each matrix size and writes the results to `data.txt`.

## Strassen Matrix Multiplication

### Implementation
The `strassen` method implements the Strassen algorithm for matrix multiplication. It divides the matrices into submatrices recursively and uses seven recursive multiplications to calculate the final result.

### Usage
Similar to the simple approach, the application prompts the user for matrix size parameters to generate data for Strassen matrix multiplication. It measures the execution time for each matrix size and writes the results to `data.txt`.

## Data Format
The `data.txt` file contains tab-separated values with columns for matrix size, execution time for simple multiplication, and execution time for Strassen multiplication.

## How to Run

1. Run the application.
2. Enter the starting matrix size (`from`), ending matrix size (`to`), and increment step (`increase`).
3. View the progress and wait for the execution to complete.
4. Check the `data.txt` file for the results.

<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/4.Algorithm-Design-Module/4.MatrixSpeedTest/Screenshots/Screenshot1.png"/>

Feel free to analyze the data to compare the performance of the simple matrix multiplication and the Strassen algorithm for different matrix sizes.
