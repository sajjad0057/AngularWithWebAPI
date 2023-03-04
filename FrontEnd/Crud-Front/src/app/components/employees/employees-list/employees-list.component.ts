import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
  
  employees : Employee[] = [
    {
      id : '85fd5338-4654-4a03-954a-1fdc3381b0fa',
      name : 'sajjad hossain',
      email : 'sajjad@gmail.com',
      phone : 1774135869,
      salary : 35000,
      department : 'development'
    },
    {
      id : '7c7480e1-4545-47a9-81c3-9e5cd0715ac9',
      name : 'hosne zahan',
      email : 'hosne@gmail.com',
      phone : 1774135887,
      salary : 55000,
      department : 'human resources'
    },
    {
      id : 'aa3de089-e4ec-4955-9de6-55cd1662072d',
      name : 'imam madhi',
      email : 'mahdi@gmail.com',
      phone : 1774135867,
      salary : 50000,
      department : 'business'
    },
    {
      id : 'bf37ae23-2b45-48b3-bd04-96fc22039674',
      name : 'sanwar hossain',
      email : 'sanwar@gmail.com',
      phone : 1774135855,
      salary : 33500,
      department : 'development'
    },
    {
      id : 'ee571d5e-b8bc-4fd8-8fc2-0e6fd731d5ea',
      name : 'ariful islam',
      email : 'ariful@gmail.com',
      phone : 1774135889,
      salary : 45000,
      department : 'development'
    }    
  ];


  constructor(){}
  
  ngOnInit(): void {
    
  }

}
