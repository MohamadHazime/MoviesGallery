import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomValidators } from 'src/app/validators/custom-validators';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {
  reviewForm!: FormGroup;
  @Output() close = new EventEmitter<void>();

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.reviewForm = this.fb.group({
      firstName: new FormControl(null, Validators.required),
      lastName: new FormControl(null, Validators.required),
      email: new FormControl(null, [ Validators.required, Validators.email ], CustomValidators.asyncBlockedEmail()),
      vote: new FormControl("5", Validators.required),
      comment: new FormControl(null),
    });
  }

  onSubmitReview(){
    console.log(this.reviewForm.value);
    this.reviewForm.reset();
    this.onClose();
  }

  get reviewFormControl() {
    return this.reviewForm.controls;
  }

  onClose() {
    this.close.emit();
  }

}
