using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OmniSharp.Extensions.LanguageServer.Protocol.Serialization;
using OmniSharp.Extensions.LanguageServer.Protocol.Serialization.Converters;

namespace OmniSharp.Extensions.LanguageServer.Protocol.Models
{
    public class WorkspaceEdit
    {
        /// <summary>
        /// Holds changes to existing resources.
        /// </summary>
        [Optional]
        [JsonConverter(typeof(AbsoluteUriKeyConverter<IEnumerable<TextEdit>>))]
        public IDictionary<Uri, IEnumerable<TextEdit>> Changes { get; set; }
        /// <summary>
        /// An array of `TextDocumentEdit`s to express changes to n different text documents
        /// where each text document edit addresses a specific version of a text document.
        /// where each text document edit addresses a specific version of a text document. Or it can contain
        /// above `TextDocumentEdit`s mixed with create, rename and delete file / folder operations.
        ///
        /// Whether a client supports versioned document edits is expressed via
        /// `WorkspaceCapability.workspaceEdit.documentChanges`.
        ///
        /// If a client neither supports `documentChanges` nor `workspace.workspaceEdit.resourceOperations` then
        /// only plain `TextEdit`s using the `changes` property are supported.
        /// </summary>
        [Optional]
        public Container<WorkspaceEditDocumentChange> DocumentChanges { get; set; }
    }
}
