import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonService } from 'app/shared/services/common.service';


@Component({
  selector: 'app-course-quizzes',
  templateUrl: './course-quizzes.component.html',
  styleUrls: ['./course-quizzes.component.css']
})
export class CourseQuizzesComponent implements OnInit {

  quizzes = [];
  tab = [];

  constructor(private commonService: CommonService,
    private activeRoute: ActivatedRoute,
    private router: Router) { }


  ngOnInit(): void {
    let route = 'Quiz/GetAll';
    this.commonService.getData(route)
      .subscribe(res => {
        this.quizzes = res as [];
        console.log("res", res);
      });
  }

  redirectToQuiz(QuizID: string) {
    let QuizUrl: string = `pass-quiz/${QuizID}`;
    this.router.navigate([QuizUrl]);
  }
}
