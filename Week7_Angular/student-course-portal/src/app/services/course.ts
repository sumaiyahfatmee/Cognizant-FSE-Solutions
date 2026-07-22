
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Course } from '../models/course.model';
@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private apiUrl = 'http://localhost:3000/courses';

  private courses: Course[] = [

    {
      id: 1,
      name: 'Data Structures',
      code: 'CS101',
      credits: 4,
      gradeStatus: 'passed'
    },

    {
      id: 2,
      name: 'Database Management',
      code: 'CS102',
      credits: 3,
      gradeStatus: 'pending'
    },

    {
      id: 3,
      name: 'Operating Systems',
      code: 'CS103',
      credits: 4,
      gradeStatus: 'failed'
    },

    {
      id: 4,
      name: 'Computer Networks',
      code: 'CS104',
      credits: 3,
      gradeStatus: 'passed'
    },

    {
      id: 5,
      name: 'Software Engineering',
      code: 'CS105',
      credits: 4,
      gradeStatus: 'pending'
    }

  ];

constructor(private http: HttpClient) { }
 getCourses(): Observable<Course[]> {
  return this.http.get<Course[]>(this.apiUrl);
}

getCourseById(id: number): Observable<Course> {
  return this.http.get<Course>(`${this.apiUrl}/${id}`);
}

addCourse(course: Course): void {
  this.courses.push(course);
}


}