
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CourseCard } from '../../components/course-card/course-card';
import { CourseService } from '../../services/course';

import { Course } from '../../models/course.model';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule, FormsModule, CourseCard],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList implements OnInit {

  
constructor(
  private cdr: ChangeDetectorRef,
  private courseService: CourseService,
  private router: Router,
  private route: ActivatedRoute
) {}
  isLoading = true;

  selectedCourseId: number | null = null;
  searchTerm = '';

  courses: Course[] = [];

  ngOnInit(): void {

    console.log('CourseList ngOnInit called');

    setTimeout(() => {

      console.log('Changing isLoading to false');
      this.courseService.getCourses().subscribe({

  next: (data) => {

    this.courses = data;

    this.searchTerm =
      this.route.snapshot.queryParamMap.get('search') || '';

    this.isLoading = false;

    this.cdr.detectChanges();

  }

});

    }, 1500);

  }

  trackByCourseId(index: number, course: any) {
    return course.id;
  }

  onEnroll(courseId: number) {
    console.log('Enrolling in course:', courseId);
    this.selectedCourseId = courseId;
  }
  navigateToCourse(course: Course): void {

  this.router.navigate(['courses', course.id]);

}
updateSearch(): void {

  this.router.navigate(['courses'], {
    queryParams: {
      search: this.searchTerm
    }
  });

} 

}