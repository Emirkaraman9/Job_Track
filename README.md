# jobTrack: Transparent and Feedback-Oriented Recruitment Process Management System

<img width="960" height="377" alt="image" src="https://github.com/user-attachments/assets/419e926d-1094-4a99-a829-6ba838fea190" />

## 📄 Project Status

This project is a **prototype** and lays the foundation for a system currently under active development.

## 🎯 Project Goal
Designed to solve the "black box" problem in traditional job search processes, this prototype aims to provide a system architecture where candidates are instantly informed about their application status and interview processes are measurable through mutual feedback (Evaluation System).

## 🚀 Features Within Prototype Scope

The application includes **Candidate** and **Company** modules to demonstrate core functionality:

### 👤 Candidate (Individual) Module
- **Registration & Profile Management:** Simulation of registration and login with basic user data.
- **CV Wizard:** Step-by-step data entry to create a dynamic CV with preview.
- **Job Search & Filtering:** Querying job postings in the database based on criteria.
- **Application Tracking:** Viewing status changes (e.g., Pending -> Interview) on the interface.
- **Interview Verification:** Entering feedback/ratings for completed interviews.

### 🏢 Company (Corporate) Module
- **Corporate Dashboard:** Summary screen showing system activity (Application counts, ratings).
- **Job Management:** Functions to add, delete, and edit job postings.
- **Application Pool:** Listing candidate applications and changing their status (e.g., Reject or Accept).
- **Company Profile:** Interface for editing company details.

## 🛠️ Technical Architecture (N-Tier)

The project is designed with **N-Tier Architecture** principles as an example of sustainable software architecture.

- **Language:** C# (.NET Framework / .Core)
- **Database:** Microsoft SQL Server (MSSQL)
- **Architectural Layers:**
  - **Entity Layer:** Classes corresponding to database tables.
  - **Data Access Layer (DAL):** Database connection and CRUD operations.
  - **Business Logic Layer (BLL):** Data validation and business logic.
  - **Presentation Layer (UI):** Windows Forms interfaces.

## 📸 Screenshots (Mockup & Implementation)

<img width="1008" height="721" alt="Ekran görüntüsü 2026-01-30 213320" src="https://github.com/user-attachments/assets/46948d92-0ecb-4682-aa7b-90c54441f970" />
<img width="1894" height="972" alt="Ekran görüntüsü 2026-01-30 211525" src="https://github.com/user-attachments/assets/b88404e3-0119-4d72-859b-66ed3b639fe1" />
<img width="1895" height="978" alt="Ekran görüntüsü 2026-01-30 211549" src="https://github.com/user-attachments/assets/7bd9eb14-0253-4f96-83b7-800c71338664" />
<img width="1889" height="977" alt="Ekran görüntüsü 2026-01-30 211607" src="https://github.com/user-attachments/assets/7ac24dca-e649-4274-b982-08ce0d701c3a" />
<img width="1790" height="923" alt="Ekran görüntüsü 2026-01-30 213625" src="https://github.com/user-attachments/assets/9f625bd1-0feb-41e7-b16a-46fdd0a258dd" />
<img width="1791" height="924" alt="Ekran görüntüsü 2026-01-30 213637" src="https://github.com/user-attachments/assets/60e39e3c-a48e-473b-89bf-99f6546091de" />
<img width="1796" height="924" alt="Ekran görüntüsü 2026-01-30 213655" src="https://github.com/user-attachments/assets/14795f0e-f190-4859-b159-a9340f05009e" />
<img width="1793" height="925" alt="Ekran görüntüsü 2026-01-30 213710" src="https://github.com/user-attachments/assets/008d97b4-9bf1-4f3c-a537-3438224863cc" />
<img width="1799" height="928" alt="Ekran görüntüsü 2026-01-30 213726" src="https://github.com/user-attachments/assets/5085e148-2962-420e-a7e5-22788e77f380" />

<img width="1813" height="929" alt="Ekran görüntüsü 2026-01-30 213350" src="https://github.com/user-attachments/assets/a6a0c09d-955e-4e16-8b9e-f1df0faac073" />
<img width="1813" height="933" alt="Ekran görüntüsü 2026-01-30 213407" src="https://github.com/user-attachments/assets/84afee76-3c13-4b54-95cb-a311dc56a0e4" />
<img width="1811" height="934" alt="Ekran görüntüsü 2026-01-30 213421" src="https://github.com/user-attachments/assets/306b2025-601b-4cc9-a7f3-0dea5cd8ad96" />
<img width="1809" height="928" alt="Ekran görüntüsü 2026-01-30 215507" src="https://github.com/user-attachments/assets/4161825c-96bb-462e-8bae-a75b9ea9111b" />
<img width="1809" height="934" alt="Ekran görüntüsü 2026-01-30 215535" src="https://github.com/user-attachments/assets/9a17bcd2-03d2-4c3d-8154-1d5e451b4b55" />
<img width="1810" height="929" alt="Ekran görüntüsü 2026-01-30 215603" src="https://github.com/user-attachments/assets/9c0a14df-0148-48ed-9537-7e13ad6c182f" />

*(Note: Screenshots represent the interfaces at the prototype stage of the project.)*

## ⚙️ Installation and Execution

To test this prototype in your local environment:

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/Emirkaraman9/Job_Track](https://github.com/Emirkaraman9/Job_Track)
    ```
2.  **Database Setup:**
    - Create the necessary tables on your local SQL Server using the provided `script.sql` file.
    - Adjust the connection string in the `App.config` file according to your server.
3.  **Launch:**
    - Open the `jobTrack.slnx` file in Visual Studio and press **Start**.

## 🔮 Future Roadmap
This project is currently a prototype containing basic functions. Features planned for future stages include:
- Migration to a web-based (ASP.NET Core) interface.
- Integration of real-time email/SMS notifications.
- AI-supported candidate-job matching algorithm.

## 👥 Developers

This project was developed as a **Visual Programming** course project at **Istanbul Beykent University - Computer Engineering Department**.

- **Emir Karaman** ->  https://github.com/Emirkaraman9
- **Metehan Şener**  -> https://github.com/mete-HAN-C
- **Serkan Demirtaş** -> https://github.com/serkandemirtas

## 📄 License

This serves as a **prototype** for a project currently **under development**.
