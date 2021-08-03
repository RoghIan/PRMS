import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublishersComponent } from './publishers.component';
import { PublisherItemComponent } from './publisher-item/publisher-item.component';
import { SharedModule } from '../shared/shared.module';
import { PublisherDetailsComponent } from './publisher-details/publisher-details.component';
import { PublishersRoutingModule } from './publishers-routing.module';

@NgModule({
  declarations: [
    PublishersComponent,
    PublisherItemComponent,
    PublisherDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PublishersRoutingModule,
  ]
})
export class PublishersModule {}
