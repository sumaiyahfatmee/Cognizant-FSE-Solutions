import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Api } from '../../services/api';
import { EnrollmentService } from '../../services/enrollment';
import { Course } from '../../models/course.model';

@Component({
  selector: 'app-student-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student-profile.html',
  styleUrl: './student-profile.css'
})
export class StudentProfile implements OnInit {

  users: any[] = [];
  enrolledCourses: Course[] = [];

  constructor(
  private api: Api,
  private enrollmentService: EnrollmentService
) {}

  ngOnInit(): void {
    this.api.getUsers().subscribe((data) => {
      this.users = data;
    });
    this.enrollmentService.getEnrolledCourses().subscribe({

  next: (courses) => {

    this.enrolledCourses = courses;

  }

});
  }

}