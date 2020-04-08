﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentAwareResizeLayer.cs" company="James Jackson-South">
//   Copyright (c) James Jackson-South.
//   Licensed under the Apache License, Version 2.0.
// </copyright>
// <summary>
//   Encapsulates the properties required to resize an image using content aware resizing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageProcessor.Plugins.Cair.Imaging
{
    using System.Drawing;

    /// <summary>
    /// Encapsulates the properties required to resize an image using content aware resizing.
    /// </summary>
    public class ContentAwareResizeLayer
    {
        /// <summary>
        /// The expected output type.
        /// </summary>
        private OutputType outputType = OutputType.Cair;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentAwareResizeLayer"/> class.
        /// </summary>
        /// <param name="size">
        /// The <see cref="T:System.Drawing.Size"/> containing the width and height to set the image to.
        /// </param>
        public ContentAwareResizeLayer(Size size)
        {
            this.Size = size;
        }

        /// <summary>
        /// Gets or sets the content aware resize convolution type (Default ContentAwareResizeConvolutionType.Prewitt).
        /// </summary>
        public ConvolutionType ConvolutionType { get; set; } = ConvolutionType.Prewitt;

        /// <summary>
        /// Gets or sets the energy function (Default EnergyFunction.Forward).
        /// </summary>
        public EnergyFunction EnergyFunction { get; set; } = EnergyFunction.Forward;

        /// <summary>
        /// Gets or sets the expected output type.
        /// </summary>
        public OutputType OutputType
        {
            get
            {
                return this.outputType;
            }

            set
            {
                this.outputType = value;
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets the the file path to a bitmap file that provides weight indicators specified using
        /// color to guide preservation of image portions during carving. 
        /// <remarks>
        /// The following colors define weight guidance.
        /// &#10; <see cref="Color.Green"/> - Protect the weight.
        ///  &#10; <see cref="Color.Red"/> - Remove the weight.
        ///  &#10; <see cref="Color.Black"/> - No weight.
        /// </remarks>
        /// </summary>
        public string WeightPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to assign multiple threads to the resizing method.
        /// (Default true)
        /// </summary>
        public bool Parallelize { get; set; } = true;

        /// <summary>
        /// Gets or sets the timeout in milliseconds to attempt to resize for (Default 60000).
        /// </summary>
        public int Timeout { get; set; } = 60000;

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is ContentAwareResizeLayer resizeLayer))
            {
                return false;
            }

            return this.Size == resizeLayer.Size
                && this.ConvolutionType == resizeLayer.ConvolutionType
                && this.EnergyFunction == resizeLayer.EnergyFunction
                && this.OutputType == resizeLayer.OutputType
                && this.Parallelize == resizeLayer.Parallelize
                && this.Timeout == resizeLayer.Timeout
                && this.WeightPath == resizeLayer.WeightPath;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => (this.ConvolutionType, this.EnergyFunction, this.Parallelize, this.OutputType, this.Timeout, this.Size, this.WeightPath).GetHashCode();
    }
}
