import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { noCourseCode } from '../../validators/custom-validator';
import { emailTakenValidator } from '../../validators/async-validator';

import {
  FormArray,
  FormControl,
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

@Component({
  selector: 'app-reactive-enrollment',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reactive-enrollment.html',
  styleUrl: './reactive-enrollment.css'
})
export class ReactiveEnrollment {
  submittedData: any = null;

  enrollmentForm: FormGroup;

  submitted = false;

  constructor(private fb: FormBuilder) {

    this.enrollmentForm = this.fb.group({


      studentName: ['', [Validators.required, Validators.minLength(3)]],

      studentEmail: [
  '',
  [Validators.required, Validators.email],
  [emailTakenValidator()]
],

      courseId: [
  '',
  [
    Validators.required,
    noCourseCode
  ]
],

      preferredSemester: ['', Validators.required],

      agreeToTerms: [false, Validators.requiredTrue],
      additionalCourses: this.fb.array([])

    });

  }
onSubmit(): void {

  console.log(this.enrollmentForm.value);

  this.submittedData = this.enrollmentForm.value;

  this.submitted = true;

}
addCourse() {
  this.additionalCourses.push(
    new FormControl('', Validators.required)
  );
}

removeCourse(index: number) {
  this.additionalCourses.removeAt(index);
}

  resetForm(): void {

  this.enrollmentForm.reset();

  this.submitted = false;

  this.submittedData = null;

}
get additionalCourses(): FormArray {
  return this.enrollmentForm.get('additionalCourses') as FormArray;
}

}