using System;

namespace VTCO.Utils.DeepZoomComposer
{
    /// <summary>
    /// Provides data for the DeepZoomCreationProgress. 
    /// </summary>
    public class DeepZoomCreationProgressEventArgs : EventArgs
    {
        private readonly int m_creationProgress;
        public int CreationProgress
        {
            get { return m_creationProgress; }
        }

        public DeepZoomCreationProgressEventArgs(int percentage)
        {
            if (percentage > 100)
                percentage = 100;
            m_creationProgress = percentage;
        }
    }
}
