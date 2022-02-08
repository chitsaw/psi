﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.Psi.MixedReality
{
    using HoloLens2ResearchMode;
    using Microsoft.Psi;

    /// <summary>
    /// Source component that publishes gyroscope data on a stream.
    /// </summary>
    public class Gyroscope : ResearchModeImu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gyroscope"/> class.
        /// </summary>
        /// <param name="pipeline">The pipeline to add the component to.</param>
        public Gyroscope(Pipeline pipeline)
            : base(pipeline, ResearchModeSensorType.ImuGyro)
        {
        }

        /// <inheritdoc/>
        protected override void ProcessSensorFrame(IResearchModeSensorFrame sensorFrame)
        {
            this.PostSamples(
                sensorFrame,
                (sensorFrame as ResearchModeGyroFrame).GetCalibratedGyroSamples(),
                f => (f.X, f.Y, f.Z),
                f => f.VinylHupTicks);
        }
    }
}
