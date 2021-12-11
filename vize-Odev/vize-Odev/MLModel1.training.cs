﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace Vize_Odev
{
    public partial class MLModel1
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new []{new InputOutputColumnPair(@"Sex", @"Sex"),new InputOutputColumnPair(@"ChestPainType", @"ChestPainType"),new InputOutputColumnPair(@"RestingECG", @"RestingECG"),new InputOutputColumnPair(@"ExerciseAngina", @"ExerciseAngina"),new InputOutputColumnPair(@"ST_Slope", @"ST_Slope")})      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Age", @"Age"),new InputOutputColumnPair(@"RestingBP", @"RestingBP"),new InputOutputColumnPair(@"Cholesterol", @"Cholesterol"),new InputOutputColumnPair(@"FastingBS", @"FastingBS"),new InputOutputColumnPair(@"MaxHR", @"MaxHR"),new InputOutputColumnPair(@"Oldpeak", @"Oldpeak")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Sex",@"ChestPainType",@"RestingECG",@"ExerciseAngina",@"ST_Slope",@"Age",@"RestingBP",@"Cholesterol",@"FastingBS",@"MaxHR",@"Oldpeak"}))      
                                    .Append(mlContext.Regression.Trainers.FastForest(new FastForestRegressionTrainer.Options(){NumberOfTrees=4,FeatureFraction=0.460711892335723F,LabelColumnName=@"HeartDisease",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
}