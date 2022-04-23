import { Component } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { Result } from '../shared/models/Result';
import { Quiz } from '../shared/models/Quiz';
import { Question } from '../shared/models/Question';
import { Option } from '../shared/models/Option';
import { CommonService } from 'app/shared/services/common.service';
import { TestConfig } from 'app/shared/models/Test-config';


@Component({
  selector: 'app-pass-quiz',
  templateUrl: './pass-quiz.component.html',
  styleUrls: ['./pass-quiz.component.css']
})
export class PassQuizComponent {
  id: string = this.activeRoute.snapshot.paramMap.get('QuizID');
  result: Result = new Result();
  quiz: Quiz = new Quiz();
  config : TestConfig = {
    'allowBack': true,
    'allowReview': true,
    'autoMove': false,  // if true, it will move to next question automatically when answered.
    'duration': 10,  // indicates the time in which quiz needs to be completed. 0 means unlimited.
    'pageSize': 1,
    'requiredAll': false,  // indicates if you must answer all the questions before submitting.
    'richText': false,
    'shuffleQuestions': false,
    'shuffleOptions': false,
    'showClock': true,
    'showPager': true,
    'theme': 'none'
  };

  quizzes: Quiz[]=[];
  Questions: Question[]=[];
  options: Option[]=[];


  res: any;
  score: number;
  count: number = 0;


  mode: string = 'quiz';
  QuesID: string;


  pager = {
    index: 0,
    size: 1,
    count: 1
  };

  constructor(private commonService: CommonService, private activeRoute: ActivatedRoute) { }

  ngOnInit() {

    //this.startTimer();
this.getData();
   
  }

  getData()
  {
    let route = `Quiz/GetById/${this.id}`;
    this.commonService.getData(route).subscribe((data: any) =>
      {
        console.log("my data", data)
        this.quiz = data;
        this.pager.count = this.quiz.questions.length;
        this.quiz.questions.slice(this.pager.index, this.pager.index + this.pager.size);
      })
  }

  get filteredQuestions() {
    return (this.quiz.questions) ?
      this.quiz.questions.slice(this.pager.index, this.pager.index + this.pager.size) : [];
  }

  onSelect(question: Question, option: Option) {
    if (question.type === "Single choice") {
      question.options.forEach((element) => { if (element.id !== option.id) element.selected = false; });
    }
    else if (question.type === "Multichoice") {
      question.options.forEach((element) => {
        if (element.id !== option.id) {
          element.selected === false ? element.selected = false : element.selected = true;
          console.log("option", element.selected)
        }
      });
    }
    if (this.config.autoMove) {
      this.goTo(this.pager.index + 1);
    }
  }

  goTo(index: number) {
    if (index >= 0 && index < this.pager.count) {
      this.pager.index = index;
      this.mode = 'quiz';
    }
  }

  isAnswered(index) {
    return this.quiz.questions[index].options.find(element => element.selected) ? 'Answered' : 'Not Answered';
  };

  isCorrect(question: Question) {
    return question.options.every(element => element.selected === element.value) ? 'correct' : 'wrong';
  };

  onSubmit() {
    this.count++;
    console.log(this.count);
    let time = new Date();
    let correctCount: number = 0;

    for (let index = 0; index < this.quiz.questions.length; index++) {
      if (this.isCorrect(this.quiz.questions[index]) === 'correct') { correctCount++ };
    }

    console.log(correctCount);
    this.score = Math.round((correctCount / this.quiz.questions.length) * 100);
    this.result.Score = this.score;
    this.result.QuizID = this.id;
    this.result.Count = this.count;
    this.result.time = time;
    this.mode = 'result';
  }
}