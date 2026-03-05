import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActsAPIService } from '../../services/acts-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-new-person-dialog',
  templateUrl: './new-person-dialog.component.html',
  styleUrls: ['./new-person-dialog.component.scss']
})
export class NewPersonDialogComponent {
  personForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private actsAPIService: ActsAPIService,
    private snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<NewPersonDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.personForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]]
    });
  }

  onSubmit(): void {
    if (this.personForm.valid) {
      const name = this.personForm.value.name;
      this.actsAPIService.CreatePerson(name).subscribe({
        next: (id) => {
          this.snackBar.open(`Person created successfully with ID: ${id}`, 'Close', { duration: 3000 });
          this.dialogRef.close(true); // Close dialog and indicate success
        }
      });
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
