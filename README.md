# GUCera Online Courses Management System

## Table of Contents

1. [Project Overview](#project-overview)
2. [System Requirements](#system-requirements)
    2.1 [Users](#users)
        2.1.1 [Admin](#admin)
        2.1.2 [Student](#student)
        2.1.3 [Instructors](#instructors)
    2.2 [Courses and Certificates](#courses-and-certificates)
    2.3 [Assignments](#assignments)
    2.4 [Payment Methods and Promotions](#payment-methods-and-promotions)
3. [User Stories](#user-stories)
4. [Web Application Components](#web-application-components)
    4.1 [General Component](#general-component)
    4.2 [Student Component - Part I](#student-component-part-i)
    4.3 [Student Component - Part II](#student-component-part-ii)
    4.4 [Instructor Component](#instructor-component)
    4.5 [Admin Component](#admin-component)

## Project Overview

GUCera is an open online course provider that offers massive open online courses and certificates. Instructors can upload course content for students in any field. Students are allowed to take any course they like according to their course level, then receive a final grade and a certificate based on their grades in the course. The aim of the project is to implement an Online Courses website that provides these features to students and professors.

## System Requirements

### Users

Different types of users can use the website: Admin, Instructor, or Student. Users can only be one type of the three. Any user can view and search all the available courses offered through the website. Any user should have a name (First and last name), password, gender, and an e-mail. The user can also have mobile number(s), and address. After registration, an automatic unique ID (numeric) should be set to each user and displayed to them.

#### Admin

An Admin can review all the courses added by the instructors. The admin should be able to accept courses. Furthermore, an Admin can issue a promo code that will be used for a discount in courses. Any admin can give any student a promo code.

#### Student

After registration, a student can apply for a course. A student should be able to enroll in any number of courses. Upon course acceptance by the admin, the student is allowed to enroll in this course. Each student should have a GPA, which is calculated as an average of their grades in all the courses they have finished. Students can also rate the instructors of the courses they have taken and complete assignments.

#### Instructors

An Instructor is responsible for managing a course in terms of adding course content and defining assignments. Instructors can teach any number of courses, add other instructors to a course, and view and grade assignments.

### Courses and Certificates

Each course has its own details such as id, credit hours, name, course description, price, and content. Courses can be taken by any number of students and can be taught by one or more instructors. The system keeps track of which instructor taught which student in which course. Each course has assignments that contribute to the final grade.

### Assignments

There are 3 types of assignments: exams, quizzes, and projects, each with its own weight, deadline, and content. Students are required to complete assignments of different types to calculate their final grade in a course.

### Payment Methods and Promotions

Students can pay for a course using credit cards. Promo codes can be issued by admins and used by students for discounts.

## User Stories

Detailed user stories are outlined for different types of users: unregistered users, registered users, admin, students, and instructors. These stories describe the actions that users can perform on the website.

## Web Application Components

The web application is divided into several components, each catering to different user roles and functionalities. These components include General, Student (Part I and Part II), Instructor, and Admin components.

