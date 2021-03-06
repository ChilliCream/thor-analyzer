﻿using System;
using System.Collections.Generic;

#if LEGACY
using Microsoft.Diagnostics.Tracing;
#else
using System.Diagnostics.Tracing;
#endif

namespace Thor.Analyzer
{
    /// <summary>
    /// Represents an <see cref="EventSource"/> event schema.
    /// </summary>
    public class EventSchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventSchema"/> class.
        /// </summary>
        /// <param name="schema">An event provider schema.</param>
        /// <param name="id">An event identifier.</param>
        /// <param name="name">An event name.</param>
        /// <param name="level">An event level.</param>
        /// <param name="task">An event task.</param>
        /// <param name="taskName">An event task name.</param>
        /// <param name="opcode">An event opcode.</param>
        /// <param name="keywords">A event keyword mask.</param>
        /// <param name="version">An event version.</param>
        /// <param name="payload">An event payload.</param>
        public EventSchema(EventSourceSchema schema, int id, string name,
            EventLevel level, EventTask task, string taskName, EventOpcode opcode,
            EventKeywords keywords, int version, IReadOnlyCollection<string> payload)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            EventSource = schema;
            Id = id;
            Name = name;
            Level = level;
            Task = task;
            TaskName = taskName;
            Opcode = opcode;
            Keywords = keywords;
            Version = version;
            Payload = payload;
        }

        /// <summary>
        /// Gets the event ID.
        /// </summary>
        /// <value>The event ID.</value>
        public int Id { get; }

        /// <summary>
        /// Gets the event task.
        /// </summary>
        /// <remarks>
        /// Events for a given provider can be given a group identifier called a Task that 
        /// indicates the broad area within the provider that the event pertains to (for example 
        /// the Kernel provider has Tasks for Process, Threads, etc). 
        /// </remarks>
        /// <value>The event task.</value>
        public EventTask Task { get; }

        /// <summary>
        /// Gets the task name.
        /// </summary>
        /// <value>The task name.</value>
        public string TaskName { get; }

        /// <summary>
        /// Gets the payload names that maps to the event signature parameter names.
        /// </summary>
        /// <value>The event payload.</value>
        public IReadOnlyCollection<string> Payload { get; }

        /// <summary>
        /// Gets the operation code.
        /// </summary>
        /// <remarks>
        /// Each event has a Type identifier that indicates what kind of an event is being logged. 
        /// Note that providers are free to extend this set, so the id may not be just the value in 
        /// <see cref="Opcode"/>.
        /// </remarks>
        /// <value>The operation code.</value>
        public EventOpcode Opcode { get; }

        /// <summary>
        /// Gets the event level.
        /// </summary>
        /// <value>The event level.</value>
        public EventLevel Level { get; }

        /// <summary>
        /// Gets the event version.
        /// </summary>
        /// <value>The event version.</value>
        public int Version { get; }

        /// <summary>
        /// Gets the event keywords.
        /// </summary>
        /// <value>The event keywords.</value>
        public EventKeywords Keywords { get; }

        /// <summary>
        /// Gets the name for the event.
        /// </summary>
        /// <remarks>
        /// This is simply the concatenation of the task and operation code names.
        /// </remarks>
        /// <value>The event name.</value>
        public string Name { get; }

        /// <summary>
        /// Gets the event source schema.
        /// </summary>
        /// <value>The event source schema.</value>
        public EventSourceSchema EventSource { get; }
    }
}