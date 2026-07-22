import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { unsavedChangesGuard } from '../../guards/unsaved-changes-guard';

const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('../../pages/student-registration/student-registration').then(
        m => m.StudentRegistration
      )
  },
 {
  path: 'reactive',
  canDeactivate: [unsavedChangesGuard],
  loadComponent: () =>
    import('../../pages/reactive-enrollment/reactive-enrollment').then(
      m => m.ReactiveEnrollment
    )
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EnrollmentRoutingModule {}