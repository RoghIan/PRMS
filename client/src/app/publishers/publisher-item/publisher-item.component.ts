import { Component, Input, OnInit } from '@angular/core';
import { IPublisher } from 'src/app/shared/models/publisher';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher-item.component.html',
  styleUrls: ['./publisher-item.component.scss'],
})
export class PublisherItemComponent implements OnInit {
  @Input() publisher: IPublisher;
  constructor() {}

  ngOnInit(): void {
    if (!this.publisher.photoUrl) {
      this.publisher.photoUrl = '/assets/images/no-picture.jpg';
    }
  }
}
