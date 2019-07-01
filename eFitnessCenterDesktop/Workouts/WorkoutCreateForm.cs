﻿using eFitnessCenterDesktop.Services;
using Models.Requests.Workout;
using Models.Trainers;
using Models.Workout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFitnessCenterDesktop.Workouts
{
    public partial class WorkoutCreateForm : Form
    {
        private string _accessToken;
        private readonly ApiService _trainerApiService;
        private readonly ApiService _workoutTypeApiService;
        private readonly ApiService _workoutApiService;

        private readonly Workout _workout;

        public WorkoutCreateForm(string accessToken, Workout workout)
        {
            InitializeComponent();
            _accessToken = accessToken;
            _workout = workout;
            _trainerApiService = new ApiService("trainers", _accessToken);
            _workoutTypeApiService = new ApiService("workoutType", _accessToken);
            _workoutApiService = new ApiService("workout", _accessToken);
            initFormData();
        }

        public async Task initFormData()
        {
            List<Trainer> trainers = await _trainerApiService.GetAll<List<Trainer>>(null);
            cbTrainer.DataSource = trainers;
            cbTrainer.ValueMember = "Id";
            cbTrainer.DisplayMember = "Name";

            List<WorkoutType> workoutTypes = await _workoutTypeApiService.GetAll<List<WorkoutType>>(null);
            cbWorkoutType.DataSource = workoutTypes;
            cbWorkoutType.ValueMember = "Id";
            cbWorkoutType.DisplayMember = "Name";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            WorkoutCreateRequest createRequest = new WorkoutCreateRequest
            {
                Description = tbDescription.Text,
                Difficulty = cbDifficulty.Text,
                Duration = int.Parse(cbDuration.Text),
                Name = tbName.Text,
                TrainerId = int.Parse(cbTrainer.SelectedValue.ToString()),
                WorkoutTypeId = int.Parse(cbWorkoutType.SelectedValue.ToString())
            };

            await _workoutApiService.Create<Workout>(createRequest);
        }
    }
}