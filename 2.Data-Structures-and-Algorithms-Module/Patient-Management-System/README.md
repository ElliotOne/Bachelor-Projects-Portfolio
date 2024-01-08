# C# Windows Form Application: Patient-Management-System

## Overview

Welcome to the Patient Management System Windows Forms application! This program allows you to efficiently manage patients, their information, and appointments through a user-friendly interface.

## Forms

### Login Form

- The application starts with a login form.
- Credentials are checked against the information in `login.txt`.

### Secretary Panel Form

The Secretary Panel Form allows the secretary to efficiently manage patient appointments by adding new patients to the system.

- **Add a New Patient:**
  - Input the patient's first and last name.
  - Choose the respective doctor to attend to the patient.
  - Specify the patient's status:
    - Emergency: High or Low emergency.
    - Normal.
  - Patients are then queued for each doctor based on the priority of their medical condition.

#### How Queue Functionality Works:

- **Emergency Queue:**
  - Patients with high emergency status are given priority.
  - Followed by patients with low emergency status.

- **Normal Queue:**
  - Patients are queued based on their arrival.

## How to Use

1. **Adding a New Patient:**
   - Enter the patient's name, choose the doctor, and specify the patient's status.
   - Click the "Add Patient" button.

Feel free to efficiently manage patient appointments and queue prioritization with this Windows Forms application!


### Doctor Panel Form

The Doctor Panel Form provides the following functionalities for doctors managing patient appointments.

- **View List of Appointments:**
  - Displays a list of appointments associated with the logged-in doctor.
  - Appointments are categorized based on patient status (Emergency or Normal) and priority.

- **Visit Patients:**
  - Click the "Visit" button to attend to the patient.
  - For emergency patients, high-priority cases are addressed first, followed by low-priority cases.
  - Normal patients are visited based on their arrival.

## Login Process

1. Run the application.
2. Enter your login credentials in the Login Form.
3. Based on the entered credentials:
   - If secretary credentials, open the Secretary Panel Form.
   - If doctor credentials, open the Doctor Panel Form.
   - Otherwise, show an appropriate error message.

## How to Use

1. **Login:**
   - Open the application and enter your login credentials.
   - Navigate to either the Secretary Panel or the Doctor Panel based on your role.
<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/2.Data-Structures-and-Algorithms-Module/Patient-Management-System/Screenshots/login.png"/>

2. **Secretary Panel:**
   - Choose an option from the menu in the Secretary Panel Form.
   - Follow the prompts to perform the desired operation.
   - Explore and manage patient appointments efficiently.
<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/2.Data-Structures-and-Algorithms-Module/Patient-Management-System/Screenshots/medical%20secretary%20panel.png"/>

3. **Doctor Panel:**
   - View a list of appointments associated with the logged-in doctor.
   - Click the "Visit" button to attend to the patient.
<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/2.Data-Structures-and-Algorithms-Module/Patient-Management-System/Screenshots/doctor%20panel.png"/>

4. **Exit:**
   - Close the application when you are done.

Feel free to explore and efficiently manage your patient appointments with this Windows Forms application!
