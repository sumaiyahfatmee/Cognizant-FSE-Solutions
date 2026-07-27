import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseService } from '../../services/course';
import { Course } from '../../models/course.model';

@Component({
  selector: 'app-course-summary-widget',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course-summary-widget.html',
  styleUrl: './course-summary-widget.css'
})
export class CourseSummaryWidget {

  constructor(private courseService: CourseService) {}

  get totalCourses(): number {
    return 5;
  }

  addDummyCourse(): void {

  const course: Course = {

    id: this.totalCourses + 1,

    name: 'New Course',

    code: 'NEW10' + this.totalCourses,

    credits: 3,

    gradeStatus: 'pending'

  };

  this.courseService.addCourse(course).subscribe({

    next: () => {

      alert('Course Added Successfully');

    },

    error: (err) => {

      console.error(err);

    }

  });

}

  }

