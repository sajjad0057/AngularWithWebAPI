import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }

  getAllEmployees() : Observable<Employee[]>{
    return this.http.get<Employee[]>('/api/employees');
  }

  addEmployee(addEmployeeRequest:Employee) : Observable<Employee>{
    addEmployeeRequest.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Employee>('/api/employees',addEmployeeRequest)
  }

  getEmployee(id:string):Observable<Employee>{
    return this.http.get<Employee>('/api/employees/'+id);
  }

  updateEmployee(id:string, updateEmployeeRequest:Employee):Observable<Employee>{
    return this.http.put<Employee>('/api/employees/'+id,updateEmployeeRequest)
  }

  deleteEmployee(id:string): Observable<Employee>{
    return this.http.delete<Employee>('/api/employees/'+id)
  }

}
