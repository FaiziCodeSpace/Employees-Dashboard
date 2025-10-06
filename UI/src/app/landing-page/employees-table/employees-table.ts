import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

interface Employee {
  id: number;
  name: string;
  employeeId: string;
  department: string;
  salary: number;
}

@Component({
  selector: 'app-employees-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employees-table.html',
  styleUrls: ['./employees-table.css']
})
export class EmployeesTable implements OnInit {
  private readonly http = inject(HttpClient);

  employees: Employee[] = [];
  isLoading = true;
  errorMessage = '';

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.http.get<Employee[]>('https://localhost:7258/api/AdminDashboard').subscribe({
      next: (data) => {
        this.employees = data;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error fetching employees:', error);
        this.errorMessage = 'Failed to load employee data.';
        this.isLoading = false;
      }
    });
  }
}
