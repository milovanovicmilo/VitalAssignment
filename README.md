# Assignment Project

## Project Overview

Welcome to the assignment project for the Software Engineer position at VitalScientific. This project aims to assess your skills in software development. Below are the instructions to complete the project:

## Task Description
1. **Get the Zip File**: Download the provided zip file containing the assignment project.
2. **Upload to Your Repository**: Create a new public repository on your GitHub account.
3. **Task Execution**: Perform each task described in the project documentation one by one.
4. **Commit Each Task Separately**: After completing each task, commit the changes to your repository. Please ensure to make meaningful commit messages.
5. **Completion and Submission**: Once you've completed all tasks, send the link to your GitHub repository to us for review.

## Timeframe
There is no strict timeframe for completing this assignment. You're free to work on it at your own pace. However, our estimation for completing the tasks is approximately 4 hours. Feel free to allocate this time as you see fit, whether it's completing the project in one sitting or spreading it out over several days.

## Project description
This application already contains the following features, but there might be some **bugs** that need to **fixed**:

  - Allows the add ToDoLists and related items.
  - Each ToDoList must have a unique title.
  - Each item must have a unique title within the ToDoList.
  - The title of a ToDoList and items cannot exceed 200 characters.
  - Validation errors should be shown to the user.
  - The ToDoList view should be refreshed after adding a new ToDoList.
  - The items of a ToDoList can be marked as done.
  - If no ToDoList is selected, adding items should not be possible.
  - If no ToDoListItem is selected or the selected item is marked as done, the done button should be disabled.
  - The ToDoListItem view should be refreshed after adding a new ToDoListItem.

## New Features
The following features need to be implemented:
- **Displaying Error Messages**:
  - Add a feature to display validation errors as pop-ups based on MVVM design, without using the MessageBox component.

- **Weather Forecast form**:
  - Add two new entities, Country and City, with a one-to-many relationship.
  - Provide seed data for countries and cities.
  - Implement a form for Weather Forecast and add two dropdowns:
    - The first dropdown for selecting a Country.
    - The second dropdown for selecting a City, which updates based on the selected Country.
    - Selecting a City triggers a mock API call (interface definition and a fake implementation required) to fetch and display the temperature of the city and display it on the form.
  - Writing tests for this feature is a plus.

- **Simple Caching System**:
  - Develop a simple in-memory cache from scratch without using any external caching libraries, including Microsoft's. Your implementation should support basic operations such as retrieving a cached value and resetting the cache using a cache key.
  - Use this cache to store and manage ToDoList data, and reset it when becomes outdated.

- **Project Improvement Ideas**:
  - Please provide your suggestions for improving this project at the end of this file. Consider enhancements in functionality, performance, user experience, code quality, or any other areas you deem necessary.

## Guidelines
- Make sure your GitHub repository is public so that we can review your code.
- Ensure all changes are clean, well-optimized, and maintain high code quality standards.
- Refactor the codebase where necessary and commit these changes independently.
- Write clear and concise commit messages reflecting each change.

This document provides a comprehensive guide for developers to understand and contribute effectively to the ToDoList management system. For any questions or further clarifications, please consult the project's lead developer.

We wish you the best of luck and look forward to reviewing your submission!