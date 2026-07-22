import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CourseService } from '../../services/course';
import { CourseSummaryWidget } from '../../components/course-summary-widget/course-summary-widget';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    FormsModule,
    CourseSummaryWidget
  ],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit, OnDestroy {

  portalName = 'Student Course Portal';

  isPortalActive = true;

  message = '';

  searchTerm = '';

  availableCourses = 0;

  constructor(private courseService: CourseService) {}

  onEnrollClick(): void {
    this.message = 'Enrollment opened!';
  }

  ngOnInit(): void {

    this.courseService.getCourses().subscribe({

      next: (courses) => {

        console.log('Courses received:', courses);
        console.log('Length:', courses.length);

        this.availableCourses = courses.length;

        console.log('availableCourses =', this.availableCourses);

      },

      error: (err) => {

        console.error('HTTP Error:', err);

      }

    });

  }

  ngOnDestroy(): void {

    console.log('HomeComponent destroyed');

  }

}