import { Component, Input, OnInit } from '@angular/core';
import { IPublisher } from 'src/app/shared/models/publisher';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css'],
})
export class PublisherComponent implements OnInit {
  @Input() publisher: IPublisher;
  constructor() {}

  ngOnInit(): void {
    if (!this.publisher.photoUrl) {
      this.publisher.photoUrl = '/assets/images/no-picture.jpg';
    }
  }
}
