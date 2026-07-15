using System;
using System.Collections.Generic;

namespace MediaBrowser.Model.SyncPlay
{
    /// <summary>
    /// Class GroupInfoDto.
    /// </summary>
    public class GroupInfoDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupInfoDto"/> class.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="groupName">The group name.</param>
        /// <param name="state">The group state.</param>
        /// <param name="participants">The participants.</param>
        /// <param name="lastUpdatedAt">The date when this DTO has been created.</param>
        /// <param name="bufferingParticipants">The usernames of participants currently buffering and blocking the group.</param>
        /// <param name="hostUsername">The username of the group's host.</param>
        public GroupInfoDto(Guid groupId, string groupName, GroupStateType state, IReadOnlyList<string> participants, DateTime lastUpdatedAt, IReadOnlyList<string>? bufferingParticipants = null, string? hostUsername = null)
        {
            GroupId = groupId;
            GroupName = groupName;
            State = state;
            Participants = participants;
            LastUpdatedAt = lastUpdatedAt;

        /// <summary>
        /// Gets the usernames of the participants that are currently buffering and blocking the group
        /// from progressing, so clients can surface who is holding things up.
        /// </summary>
        /// <value>The usernames of the participants currently buffering.</value>
        public IReadOnlyList<string> BufferingParticipants { get; }

        /// <summary>
        /// Gets the username of the group's host. Initially the user that created the group;
        /// if the host leaves while other participants remain, the server promotes the
        /// longest-standing remaining participant. This always identifies a current member
        /// of the group, so clients can use it as a stable "who is host" identity instead of
        /// deriving it from participant list ordering.
        /// </summary>
        /// <value>The host's username.</value>
        public string HostUsername { get; }
    }
}
