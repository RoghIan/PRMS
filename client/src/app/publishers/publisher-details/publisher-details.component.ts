import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BreadcrumbService } from 'xng-breadcrumb';

import { PublishersService } from '../publishers.service';
import { IPublisher, IPostPublisher } from '../../shared/models/publisher';
import { IPublisherReport } from '../../shared/models/report';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { IDictionary } from '../../shared/models/dictionary';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-publisher-details',
  templateUrl: './publisher-details.component.html',
  styleUrls: ['./publisher-details.component.css'],
})
export class PublisherDetailsComponent implements OnInit {
  publisher: IPublisher;
  reportForm: FormGroup;
  publisherForm: FormGroup;

  titleDropdownList = [];
  titleDropdownSettings: IDropdownSettings;

  groupDropdownList = [];
  groupDropdownSettings: IDropdownSettings;

  selectedTitles: IDictionary[] = [];
  selectedGroup: IDictionary[] = [];

  constructor(
    private adminService: PublishersService,
    private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
  ) {
    this.bcService.set('@publisherDetails', '');
  }

  ngOnInit(): void {

    this.titleDropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true,
      enableCheckAll: false,
    };

    this.groupDropdownSettings = {
      singleSelection: true,
      idField: 'id',
      textField: 'name',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };

    this.loadPublisher();
    this.createReportForm();
    this.loadGroups();
    //this.loadTitles();
  }

  loadPublisher(): void {
    this.adminService
      .getPublisher(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (publisher) => {
          this.publisher = publisher;
          this.bcService.set(
            '@publisherDetails',
            `${publisher.lastName} ${publisher.firstName}`
          );

          this.createPublisherForm();
        },
        (error) => {
          console.log(error);
        }
      );
  }

  loadGroups(){
    this.adminService.getGroups().subscribe(response => {
      this.groupDropdownList = response;
    });
  }

  // loadTitles() {
  //   this.adminService.getTitles().subscribe(response => {
  //     this.titleDropdownList = response;
  //   });
  // }

  createReportForm() {

    const reportDate = new Date();
    reportDate.setMonth(new Date().getMonth() - 1);

    this.reportForm = this.fb.group({
      reportDate: [reportDate, Validators.required],
      placements: [0, Validators.required],
      hours: [null, Validators.required],
      videoShowings: [0, Validators.required],
      returnVisits: [0, Validators.required],
      bibleStudies: [0, Validators.required],
      isAuxiliary: [false, Validators.required],
    })
  }

  createPublisherForm() {
    this.publisherForm = this.fb.group({
      firstName: [this.publisher.firstName, Validators.required],
      lastName: [this.publisher.lastName, Validators.required],
      birthDate: [this.publisher.birthDate, Validators.required],
      baptismDate: [this.publisher.baptismDate, Validators.required],
      gender: [this.publisher.gender, Validators.required],
      group: [this.publisher.group, Validators.required],
    })
  }

  onGroupSelect(item: any) {
    console.log(item);
    console.log(this.selectedGroup);

  }

  onTitleSelect(item: any) {
    console.log(item);
    console.log(this.selectedTitles);

  }

  onTitlesSelectAll(items: any) {
    console.log(items);
  }

  onSubmitPublisher() {

    console.log(this.reportForm.getRawValue());

    const publisher: IPostPublisher = {
      id: this.publisher.id,
      firstName: this.publisherForm.get('firstName').value,
      //middleName: this.publisherForm.get('middleName').value,
      lastName: this.publisherForm.get('lastName').value,
      baptismDate: this.publisherForm.get('baptismDate').value,
      birthDate: this.publisherForm.get('birthDate').value,
      //photoUrl: this.publisherForm.get('photoUrl').value,
      gender: this.publisherForm.get('gender').value,
      groupId: this.selectedGroup[0].id,
    };

    console.log(publisher);


    this.adminService.putPublisher(publisher).subscribe(response => {
      console.log(response);

    });
  }

  onSubmitReport() {

    console.log(this.reportForm.getRawValue());

    const report: IPublisherReport = {
      publisherId: this.publisher.id,
      reportDate: this.reportForm.get('reportDate').value,
      placements: this.reportForm.get('placements').value,
      hours: this.reportForm.get('hours').value,
      videoShowings: this.reportForm.get('videoShowings').value,
      returnVisits: this.reportForm.get('returnVisits').value,
      bibleStudies: this.reportForm.get('bibleStudies').value,
      auxiliary: this.reportForm.get('isAuxiliary').value,
    };

    console.log(report);

    this.adminService.postPublisherReport(report).subscribe(response => {
      this.toastr.success('save Successfully');
      this.router.navigate(['/publishers'])

    },error => {

      this.toastr.error(error);
    });
  }
}
