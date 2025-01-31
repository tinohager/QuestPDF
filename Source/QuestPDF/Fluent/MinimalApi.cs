﻿using System;
using QuestPDF.Drawing;
using QuestPDF.Infrastructure;

namespace QuestPDF.Fluent
{
    public class Document : IDocument
    {
        private Action<IDocumentContainer> ContentSource { get; }
        private DocumentMetadata Metadata { get; set; } = DocumentMetadata.Default;
        private DocumentSettings Settings { get; set; } = DocumentSettings.Default;

        private Document(Action<IDocumentContainer> contentSource)
        {
            ContentSource = contentSource;
        }
        
        public static Document Create(Action<IDocumentContainer> handler)
        {
            return new Document(handler);
        }

        public Document WithMetadata(DocumentMetadata metadata)
        {
            Metadata = metadata ?? Metadata;
            return this;
        }
        
        public Document WithSettings(DocumentSettings settings)
        {
            Settings = settings ?? Settings;
            return this;
        }
        
        #region IDocument

        public DocumentMetadata GetMetadata() => Metadata;
        public DocumentSettings GetSettings() => Settings;
        public void Compose(IDocumentContainer container) => ContentSource(container);

        #endregion
    }
}