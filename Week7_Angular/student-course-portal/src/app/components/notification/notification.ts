import { Component } from '@angular/core';
import { NotificationService } from '../../services/notification';

@Component({
  selector: 'app-notification',
  imports: [],
  templateUrl: './notification.html',
  styleUrl: './notification.css',


   providers: [NotificationService]
})
export class Notification {
   constructor(public notificationService: NotificationService) {}
}
