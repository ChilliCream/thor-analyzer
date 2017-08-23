﻿using System;
using System.Collections.Immutable;

namespace ChilliCream.Tracing.Analyzer
{
    public class EventSourceSchema
    {
        public EventSourceSchema(Guid providerId, string providerName)
        {
            if (providerId == Guid.Empty)
            {
                throw new ArgumentException(ExceptionMessages.ProviderIdMayNotBeEmpty,
                    nameof(providerId));
            }
            if (string.IsNullOrWhiteSpace(providerName))
            {
                throw new ArgumentNullException(nameof(providerName));
            }

            ProviderId = providerId;
            ProviderName = providerName;
        }

        public Guid ProviderId { get; }

        public string ProviderName { get; }

        public ImmutableArray<EventSchema> Events { get; internal set; }
    }
}