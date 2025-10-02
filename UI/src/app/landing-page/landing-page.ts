import { Component } from '@angular/core';
import { EmployeesTable } from './employees-table/employees-table';

@Component({
  selector: 'app-landing-page',
  imports: [EmployeesTable],
  templateUrl: './landing-page.html',
  styleUrl: './landing-page.css'
})
export class LandingPage {
  title = 'Employee Management System';
}
