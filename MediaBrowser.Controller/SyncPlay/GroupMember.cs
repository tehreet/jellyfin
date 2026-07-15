#nullable disable

using System;
using MediaBrowser.Controller.Session;

namespace MediaBrowser.Controller.SyncPlay
{
    /// <summary>
    /// Class GroupMember.
    /// </summary>
    public class GroupMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMember"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public GroupMember(SessionInfo session)
        {
            SessionId = session.Id;
            UserId = session.UserId;
            UserName = session.UserName;
            JoinedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the identifier of the session.
        /// </summary>
        /// <value>The session identifier.</value>
        public string SessionId { get; }

        /// <summary>
        /// Gets the identifier of the user.
        /// </summary>
        /// <value>The user identifier.</value>
        public Guid UserId { get; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <value>The username.</value>
        public string UserName { get; }

        /// <summary>
        /// Gets the time this member was added to the group. Used to pick the
        /// longest-standing member deterministically, e.g. when the host leaves
        /// and a new host has to be chosen among the remaining participants.
        /// </summary>
        /// <value>The date the member joined the group.</value>
        public DateTime JoinedAt { get; }

        /// <summary>
        /// Gets or sets the ping, in milliseconds.
        /// </summary>
        /// <value>The ping.</value>
        public long Ping { get; set; }

        /// <summary>
        /// Gets or sets the last time <see cref="Ping"/> was updated by the session.
        /// </summary>
        /// <value>The date of the last ping update, or <c>null</c> if never reported.</value>
        public DateTime? LastPingUpdate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this member is buffering.
        /// </summary>
        /// <value><c>true</c> if member is buffering; <c>false</c> otherwise.</value>
        public bool IsBuffering { get; set; }

        /// <summary>
        /// Gets or sets the time at which this member started its current buffering period.
        /// </summary>
        /// <value>The date the member started buffering, or <c>null</c> if not buffering.</value>
        public DateTime? BufferingSince { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this member has genuinely caught up with
        /// the group (i.e. was reported not-buffering) at least once since the last time
        /// buffering was reset for the whole group (see <see cref="IGroupStateContext.SetAllBuffering"/>).
        /// This is preserved across individual re-buffering periods so it can be used to
        /// distinguish a client that is still preparing playback for the first time
        /// (e.g. waiting on a transcode to start) from one that has already caught up
        /// once and is now re-buffering because of network drift.
        /// </summary>
        /// <value><c>true</c> if the member has caught up since the last group-wide reset; <c>false</c> otherwise.</value>
        public bool HasCaughtUpSinceReset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this member is following group playback.
        /// </summary>
        /// <value><c>true</c> to ignore member on group wait; <c>false</c> if they're following group playback.</value>
        public bool IgnoreGroupWait { get; set; }
    }
}
