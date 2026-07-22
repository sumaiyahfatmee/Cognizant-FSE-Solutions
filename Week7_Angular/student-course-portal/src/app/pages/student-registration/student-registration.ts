import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-student-registration',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './student-registration.html',
  styleUrl: './student-registration.css'
})
export class StudentRegistration {

  enrollment = {
    studentName: '',
    studentEmail: '',
    courseId: null as number | null,
    preferredSemester: '',
    agreeToTerms: false
  };

  submitted = false;

  onSubmit(form: NgForm): void {

    console.log('Form Value:', form.value);
    console.log('Form Valid:', form.valid);

    this.submitted = true;

  }

  resetForm(form: NgForm): void {

    form.resetForm();

    this.submitted = false;

  }

}