# Community Event Planner

## Introduction

Community Event Planner is a .NET 8 Blazor server application that allows users to create and manage community events. Users can register, log in, and sign up for events. 

## Features

- User registration and login.
- Create and edit events.
- Sign up for events.
- View event registrations. Only those in the future are displayed, and are sorted by description alphabetical order.
- Secure authentication and data validation. The list of events contains usernames and email addresses to facilitate event organisation and socialising, however this data is hidden to anyone not logged in with a registered account.

## Setup Instructions

### Prerequisites

- .NET 8 SDK or later
- SQLite

## API Endpoints

/: The home index page from where users can view events, create new events, and navigate to event registrations.
/event-registrations: Admin page to view all event registrations.
/event-signup: Page for users to sign up for events.
/login: Login page for existing users.
/logout: Logout page.
/register: Registration page for new users.

## Additional Steps for Scalability
- Data chaching.
- Load balancing when distributing network traffic.
- Use more asynchronous operations.
- Scroll bars on tables, perhaps using pages on the table data to navigate large datasets.
- Improved layout for better ease of use with large datasets.
- Logging for metrics.
- User testing for feedback to drive further improvements for scalability.

## Additional Steps for Security
- Additional steps should be taken when registering accounts, such as email verification.
- Passwords should be encrypted with hashing algorithms.
- Sanitisation of user inputs to protect against SQL injection.
- More error handling.
- Logging for troubleshooting.