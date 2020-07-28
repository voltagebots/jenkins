using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Grocedy.Domain.Models
{
    public partial class GrocedyContext : DbContext
    {
        public GrocedyContext()
        {
        }

        public GrocedyContext(DbContextOptions<GrocedyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WpCommentmeta> WpCommentmeta { get; set; }
        public virtual DbSet<WpComments> WpComments { get; set; }
        public virtual DbSet<WpIcwpWpsfAuditTrail> WpIcwpWpsfAuditTrail { get; set; }
        public virtual DbSet<WpIcwpWpsfEvents> WpIcwpWpsfEvents { get; set; }
        public virtual DbSet<WpIcwpWpsfGeoip> WpIcwpWpsfGeoip { get; set; }
        public virtual DbSet<WpIcwpWpsfIpLists> WpIcwpWpsfIpLists { get; set; }
        public virtual DbSet<WpIcwpWpsfNotes> WpIcwpWpsfNotes { get; set; }
        public virtual DbSet<WpIcwpWpsfScanner> WpIcwpWpsfScanner { get; set; }
        public virtual DbSet<WpIcwpWpsfScanq> WpIcwpWpsfScanq { get; set; }
        public virtual DbSet<WpIcwpWpsfSessions> WpIcwpWpsfSessions { get; set; }
        public virtual DbSet<WpIcwpWpsfSpambotCommentsFilter> WpIcwpWpsfSpambotCommentsFilter { get; set; }
        public virtual DbSet<WpIcwpWpsfStatistics> WpIcwpWpsfStatistics { get; set; }
        public virtual DbSet<WpIcwpWpsfTraffic> WpIcwpWpsfTraffic { get; set; }
        public virtual DbSet<WpLayerslider> WpLayerslider { get; set; }
        public virtual DbSet<WpLayersliderRevisions> WpLayersliderRevisions { get; set; }
        public virtual DbSet<WpLinks> WpLinks { get; set; }
        public virtual DbSet<WpLogs> WpLogs { get; set; }
        public virtual DbSet<WpOptions> WpOptions { get; set; }
        public virtual DbSet<WpPaystackFormsPayments> WpPaystackFormsPayments { get; set; }
        public virtual DbSet<WpPostmeta> WpPostmeta { get; set; }
        public virtual DbSet<WpPosts> WpPosts { get; set; }
        public virtual DbSet<WpPtsTables> WpPtsTables { get; set; }
        public virtual DbSet<WpTermRelationships> WpTermRelationships { get; set; }
        public virtual DbSet<WpTermTaxonomy> WpTermTaxonomy { get; set; }
        public virtual DbSet<WpTermmeta> WpTermmeta { get; set; }
        public virtual DbSet<WpTerms> WpTerms { get; set; }
        public virtual DbSet<WpUserReferalDetails> WpUserReferalDetails { get; set; }
        public virtual DbSet<WpUserRegistrationSessions> WpUserRegistrationSessions { get; set; }
        public virtual DbSet<WpUsermeta> WpUsermeta { get; set; }
        public virtual DbSet<WpUserpaymentsubcriptiondetails> WpUserpaymentsubcriptiondetails { get; set; }
        public virtual DbSet<WpUserreferalsMappings> WpUserreferalsMappings { get; set; }
        public virtual DbSet<WpUsers> WpUsers { get; set; }
        public virtual DbSet<WpWcDownloadLog> WpWcDownloadLog { get; set; }
        public virtual DbSet<WpWcProductMetaLookup> WpWcProductMetaLookup { get; set; }
        public virtual DbSet<WpWcTaxRateClasses> WpWcTaxRateClasses { get; set; }
        public virtual DbSet<WpWcWebhooks> WpWcWebhooks { get; set; }
        public virtual DbSet<WpWcsPaymentRetries> WpWcsPaymentRetries { get; set; }
        public virtual DbSet<WpWoocommerceApiKeys> WpWoocommerceApiKeys { get; set; }
        public virtual DbSet<WpWoocommerceAttributeTaxonomies> WpWoocommerceAttributeTaxonomies { get; set; }
        public virtual DbSet<WpWoocommerceDownloadableProductPermissions> WpWoocommerceDownloadableProductPermissions { get; set; }
        public virtual DbSet<WpWoocommerceLog> WpWoocommerceLog { get; set; }
        public virtual DbSet<WpWoocommerceOrderItemmeta> WpWoocommerceOrderItemmeta { get; set; }
        public virtual DbSet<WpWoocommerceOrderItems> WpWoocommerceOrderItems { get; set; }
        public virtual DbSet<WpWoocommercePaymentTokenmeta> WpWoocommercePaymentTokenmeta { get; set; }
        public virtual DbSet<WpWoocommercePaymentTokens> WpWoocommercePaymentTokens { get; set; }
        public virtual DbSet<WpWoocommerceSessions> WpWoocommerceSessions { get; set; }
        public virtual DbSet<WpWoocommerceShippingZoneLocations> WpWoocommerceShippingZoneLocations { get; set; }
        public virtual DbSet<WpWoocommerceShippingZoneMethods> WpWoocommerceShippingZoneMethods { get; set; }
        public virtual DbSet<WpWoocommerceShippingZones> WpWoocommerceShippingZones { get; set; }
        public virtual DbSet<WpWoocommerceTaxRateLocations> WpWoocommerceTaxRateLocations { get; set; }
        public virtual DbSet<WpWoocommerceTaxRates> WpWoocommerceTaxRates { get; set; }
        public virtual DbSet<WpWpfmBackup> WpWpfmBackup { get; set; }
        public virtual DbSet<WpWpformsEntries> WpWpformsEntries { get; set; }
        public virtual DbSet<WpWpformsEntryFields> WpWpformsEntryFields { get; set; }
        public virtual DbSet<WpWpformsEntryMeta> WpWpformsEntryMeta { get; set; }
        public virtual DbSet<WpYoastSeoLinks> WpYoastSeoLinks { get; set; }
        public virtual DbSet<WpYoastSeoMeta> WpYoastSeoMeta { get; set; }
        public virtual DbSet<WpZohocustomerMapping> WpZohocustomerMapping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=grocedydbinstance.c39clkebbobi.us-east-2.rds.amazonaws.com;port=3306;user=sylendra;password=sylendra;database=grocedydb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WpCommentmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_commentmeta");

                entity.HasIndex(e => e.CommentId)
                    .HasName("comment_id");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpComments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_comments");

                entity.HasIndex(e => e.CommentAuthorEmail)
                    .HasName("comment_author_email");

                entity.HasIndex(e => e.CommentDateGmt)
                    .HasName("comment_date_gmt");

                entity.HasIndex(e => e.CommentParent)
                    .HasName("comment_parent");

                entity.HasIndex(e => e.CommentPostId)
                    .HasName("comment_post_ID");

                entity.HasIndex(e => e.CommentType)
                    .HasName("woo_idx_comment_type");

                entity.HasIndex(e => new { e.CommentApproved, e.CommentDateGmt })
                    .HasName("comment_approved_date_gmt");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_ID")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.CommentAgent)
                    .IsRequired()
                    .HasColumnName("comment_agent")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentApproved)
                    .IsRequired()
                    .HasColumnName("comment_approved")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CommentAuthor)
                    .IsRequired()
                    .HasColumnName("comment_author")
                    .HasColumnType("tinytext");

                entity.Property(e => e.CommentAuthorEmail)
                    .IsRequired()
                    .HasColumnName("comment_author_email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentAuthorIp)
                    .IsRequired()
                    .HasColumnName("comment_author_IP")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentAuthorUrl)
                    .IsRequired()
                    .HasColumnName("comment_author_url")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasColumnName("comment_content");

                entity.Property(e => e.CommentDate)
                    .HasColumnName("comment_date")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CommentDateGmt)
                    .HasColumnName("comment_date_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CommentKarma)
                    .HasColumnName("comment_karma")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommentParent)
                    .HasColumnName("comment_parent")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.CommentPostId)
                    .HasColumnName("comment_post_ID")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.CommentType)
                    .IsRequired()
                    .HasColumnName("comment_type")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpIcwpWpsfAuditTrail>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_audit_trail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("int(3) unsigned")
                    .HasComment("Severity");

                entity.Property(e => e.Context)
                    .IsRequired()
                    .HasColumnName("context")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'none'")
                    .HasComment("Audit Context");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("smallint(5) unsigned")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Repeat Count");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.Event)
                    .IsRequired()
                    .HasColumnName("event")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'none'")
                    .HasComment("Specific Audit Event");

                entity.Property(e => e.Immutable)
                    .HasColumnName("immutable")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasComment("May Be Deleted");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Visitor IP Address");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasComment("Audit Event Description");

                entity.Property(e => e.Meta)
                    .HasColumnName("meta")
                    .HasComment("Audit Event Data");

                entity.Property(e => e.Rid)
                    .IsRequired()
                    .HasColumnName("rid")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''")
                    .HasComment("Request ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.WpUsername)
                    .IsRequired()
                    .HasColumnName("wp_username")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'-'")
                    .HasComment("WP User");
            });

            modelBuilder.Entity<WpIcwpWpsfEvents>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_events");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int(11) unsigned")
                    .HasComment("Total");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.Event)
                    .IsRequired()
                    .HasColumnName("event")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'none'")
                    .HasComment("Event ID");
            });

            modelBuilder.Entity<WpIcwpWpsfGeoip>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_geoip");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(16)
                    .HasComment("IP Address");

                entity.Property(e => e.Meta).HasColumnName("meta");
            });

            modelBuilder.Entity<WpIcwpWpsfIpLists>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_ip_lists");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.BlockedAt)
                    .HasColumnName("blocked_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ip6)
                    .HasColumnName("ip6")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsRange)
                    .HasColumnName("is_range")
                    .HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastAccessAt)
                    .HasColumnName("last_access_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.List)
                    .IsRequired()
                    .HasColumnName("list")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Transgressions)
                    .HasColumnName("transgressions")
                    .HasColumnType("smallint(1) unsigned");
            });

            modelBuilder.Entity<WpIcwpWpsfNotes>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_notes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.WpUsername)
                    .IsRequired()
                    .HasColumnName("wp_username")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'unknown'");
            });

            modelBuilder.Entity<WpIcwpWpsfScanner>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_scanner");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned")
                    .HasComment("TS Discovered");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned")
                    .HasComment("TS Soft Deleted");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("hash")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''")
                    .HasComment("Unique Item Hash");

                entity.Property(e => e.IgnoredAt)
                    .HasColumnName("ignored_at")
                    .HasColumnType("int(15) unsigned")
                    .HasComment("TS Ignored");

                entity.Property(e => e.Meta)
                    .HasColumnName("meta")
                    .HasComment("Relevant Item Data");

                entity.Property(e => e.NotifiedAt)
                    .HasColumnName("notified_at")
                    .HasColumnType("int(15) unsigned")
                    .HasComment("TS Last Notified");

                entity.Property(e => e.Scan)
                    .IsRequired()
                    .HasColumnName("scan")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Scan Type");

                entity.Property(e => e.Severity)
                    .HasColumnName("severity")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Severity");
            });

            modelBuilder.Entity<WpIcwpWpsfScanq>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_scanq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned")
                    .HasComment("TS Created");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned")
                    .HasComment("TS Soft Deleted");

                entity.Property(e => e.FinishedAt)
                    .HasColumnName("finished_at")
                    .HasColumnType("int(15) unsigned")
                    .HasComment("TS Finished");

                entity.Property(e => e.Items)
                    .HasColumnName("items")
                    .HasComment("Array of scan items");

                entity.Property(e => e.Meta)
                    .HasColumnName("meta")
                    .HasComment("Meta Data");

                entity.Property(e => e.Results)
                    .HasColumnName("results")
                    .HasComment("Array of results");

                entity.Property(e => e.Scan)
                    .IsRequired()
                    .HasColumnName("scan")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Scan Slug");

                entity.Property(e => e.StartedAt)
                    .HasColumnName("started_at")
                    .HasColumnType("int(15) unsigned")
                    .HasComment("TS Started");
            });

            modelBuilder.Entity<WpIcwpWpsfSessions>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_sessions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Browser)
                    .IsRequired()
                    .HasColumnName("browser")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastActivityAt)
                    .HasColumnName("last_activity_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.LastActivityUri)
                    .IsRequired()
                    .HasColumnName("last_activity_uri");

                entity.Property(e => e.LiCodeEmail)
                    .IsRequired()
                    .HasColumnName("li_code_email")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LoggedInAt)
                    .HasColumnName("logged_in_at")
                    .HasColumnType("int(15)");

                entity.Property(e => e.LoginIntentExpiresAt)
                    .HasColumnName("login_intent_expires_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.SecadminAt)
                    .HasColumnName("secadmin_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasColumnName("session_id")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.WpUsername)
                    .IsRequired()
                    .HasColumnName("wp_username")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpIcwpWpsfSpambotCommentsFilter>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_spambot_comments_filter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniqueToken)
                    .IsRequired()
                    .HasColumnName("unique_token")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpIcwpWpsfStatistics>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_statistics");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.ParentStatKey)
                    .IsRequired()
                    .HasColumnName("parent_stat_key")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.StatKey)
                    .IsRequired()
                    .HasColumnName("stat_key")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Tally)
                    .HasColumnName("tally")
                    .HasColumnType("int(11) unsigned");
            });

            modelBuilder.Entity<WpIcwpWpsfTraffic>(entity =>
            {
                entity.ToTable("wp_icwp_wpsf_traffic");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'200'")
                    .HasComment("HTTP Response Code");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("int(15) unsigned");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(16)
                    .HasComment("Visitor IP Address");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasComment("Request Path or URI");

                entity.Property(e => e.Rid)
                    .IsRequired()
                    .HasColumnName("rid")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''")
                    .HasComment("Request ID");

                entity.Property(e => e.Trans)
                    .HasColumnName("trans")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasComment("Trangression");

                entity.Property(e => e.Ua)
                    .HasColumnName("ua")
                    .HasComment("Browser User Agent String");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("int(11) unsigned")
                    .HasComment("User ID");

                entity.Property(e => e.Verb)
                    .IsRequired()
                    .HasColumnName("verb")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'get'")
                    .HasComment("HTTP Method");
            });

            modelBuilder.Entity<WpLayerslider>(entity =>
            {
                entity.ToTable("wp_layerslider");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DateC)
                    .HasColumnName("date_c")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DateM)
                    .HasColumnName("date_m")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FlagDeleted)
                    .HasColumnName("flag_deleted")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FlagGroup)
                    .HasColumnName("flag_group")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FlagHidden)
                    .HasColumnName("flag_hidden")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FlagPopup)
                    .HasColumnName("flag_popup")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ScheduleEnd)
                    .HasColumnName("schedule_end")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ScheduleStart)
                    .HasColumnName("schedule_start")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpLayersliderRevisions>(entity =>
            {
                entity.ToTable("wp_layerslider_revisions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DateC)
                    .HasColumnName("date_c")
                    .HasColumnType("int(10)");

                entity.Property(e => e.SliderId)
                    .HasColumnName("slider_id")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<WpLinks>(entity =>
            {
                entity.HasKey(e => e.LinkId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_links");

                entity.HasIndex(e => e.LinkVisible)
                    .HasName("link_visible");

                entity.Property(e => e.LinkId)
                    .HasColumnName("link_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.LinkDescription)
                    .IsRequired()
                    .HasColumnName("link_description")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkImage)
                    .IsRequired()
                    .HasColumnName("link_image")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasColumnName("link_name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkNotes)
                    .IsRequired()
                    .HasColumnName("link_notes")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.LinkOwner)
                    .HasColumnName("link_owner")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LinkRating)
                    .HasColumnName("link_rating")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LinkRel)
                    .IsRequired()
                    .HasColumnName("link_rel")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkRss)
                    .IsRequired()
                    .HasColumnName("link_rss")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkTarget)
                    .IsRequired()
                    .HasColumnName("link_target")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkUpdated)
                    .HasColumnName("link_updated")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.LinkUrl)
                    .IsRequired()
                    .HasColumnName("link_url")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkVisible)
                    .IsRequired()
                    .HasColumnName("link_visible")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'Y'");
            });

            modelBuilder.Entity<WpLogs>(entity =>
            {
                entity.ToTable("wp_logs");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(255)");

                entity.Property(e => e.Data)
                    .HasMaxLength(20000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpOptions>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_options");

                entity.HasIndex(e => e.Autoload)
                    .HasName("autoload");

                entity.HasIndex(e => e.OptionName)
                    .HasName("option_name")
                    .IsUnique();

                entity.Property(e => e.OptionId)
                    .HasColumnName("option_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Autoload)
                    .IsRequired()
                    .HasColumnName("autoload")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'yes'");

                entity.Property(e => e.OptionName)
                    .IsRequired()
                    .HasColumnName("option_name")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OptionValue)
                    .IsRequired()
                    .HasColumnName("option_value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpPaystackFormsPayments>(entity =>
            {
                entity.ToTable("wp_paystack_forms_payments");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("amount")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Metadata).HasColumnName("metadata");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasColumnType("int(1)");

                entity.Property(e => e.PaidAt)
                    .HasColumnName("paid_at")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Plan)
                    .IsRequired()
                    .HasColumnName("plan")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TxnCode)
                    .IsRequired()
                    .HasColumnName("txn_code")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TxnCode2)
                    .IsRequired()
                    .HasColumnName("txn_code_2")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<WpPostmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_postmeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.PostId)
                    .HasName("post_id");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpPosts>(entity =>
            {
                entity.ToTable("wp_posts");

                entity.HasIndex(e => e.PostAuthor)
                    .HasName("post_author");

                entity.HasIndex(e => e.PostName)
                    .HasName("post_name");

                entity.HasIndex(e => e.PostParent)
                    .HasName("post_parent");

                entity.HasIndex(e => new { e.PostType, e.PostStatus, e.PostDate, e.Id })
                    .HasName("type_status_date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.CommentCount)
                    .HasColumnName("comment_count")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CommentStatus)
                    .IsRequired()
                    .HasColumnName("comment_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'open'");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("guid")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MenuOrder)
                    .HasColumnName("menu_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PingStatus)
                    .IsRequired()
                    .HasColumnName("ping_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'open'");

                entity.Property(e => e.Pinged)
                    .IsRequired()
                    .HasColumnName("pinged");

                entity.Property(e => e.PostAuthor)
                    .HasColumnName("post_author")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.PostContent)
                    .IsRequired()
                    .HasColumnName("post_content")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostContentFiltered)
                    .IsRequired()
                    .HasColumnName("post_content_filtered")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostDate)
                    .HasColumnName("post_date")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostDateGmt)
                    .HasColumnName("post_date_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostExcerpt)
                    .IsRequired()
                    .HasColumnName("post_excerpt");

                entity.Property(e => e.PostMimeType)
                    .IsRequired()
                    .HasColumnName("post_mime_type")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostModified)
                    .HasColumnName("post_modified")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostModifiedGmt)
                    .HasColumnName("post_modified_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("post_name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostParent)
                    .HasColumnName("post_parent")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.PostPassword)
                    .IsRequired()
                    .HasColumnName("post_password")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostStatus)
                    .IsRequired()
                    .HasColumnName("post_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'publish'");

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasColumnName("post_title");

                entity.Property(e => e.PostType)
                    .IsRequired()
                    .HasColumnName("post_type")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'post'");

                entity.Property(e => e.ToPing)
                    .IsRequired()
                    .HasColumnName("to_ping");
            });

            modelBuilder.Entity<WpPtsTables>(entity =>
            {
                entity.ToTable("wp_pts_tables");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Css)
                    .IsRequired()
                    .HasColumnName("css");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Html)
                    .HasColumnName("html")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IsBase)
                    .HasColumnName("is_base")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsPro)
                    .HasColumnName("is_pro")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalId)
                    .HasColumnName("original_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Params)
                    .HasColumnName("params")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sort_order")
                    .HasColumnType("mediumint(5)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasColumnName("unique_id")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpTermRelationships>(entity =>
            {
                entity.HasKey(e => new { e.ObjectId, e.TermTaxonomyId })
                    .HasName("PRIMARY");

                entity.ToTable("wp_term_relationships");

                entity.HasIndex(e => e.TermTaxonomyId)
                    .HasName("term_taxonomy_id");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("object_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.TermTaxonomyId)
                    .HasColumnName("term_taxonomy_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.TermOrder)
                    .HasColumnName("term_order")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<WpTermTaxonomy>(entity =>
            {
                entity.HasKey(e => e.TermTaxonomyId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_term_taxonomy");

                entity.HasIndex(e => e.Taxonomy)
                    .HasName("taxonomy");

                entity.HasIndex(e => new { e.TermId, e.Taxonomy })
                    .HasName("term_id_taxonomy")
                    .IsUnique();

                entity.Property(e => e.TermTaxonomyId)
                    .HasColumnName("term_taxonomy_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.Parent)
                    .HasColumnName("parent")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Taxonomy)
                    .IsRequired()
                    .HasColumnName("taxonomy")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpTermmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_termmeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.TermId)
                    .HasName("term_id");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpTerms>(entity =>
            {
                entity.HasKey(e => e.TermId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_terms");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.HasIndex(e => e.Slug)
                    .HasName("slug");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TermGroup)
                    .HasColumnName("term_group")
                    .HasColumnType("bigint(10)");
            });

            modelBuilder.Entity<WpUserReferalDetails>(entity =>
            {
                entity.ToTable("wp_userReferalDetails");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(255)");

                entity.Property(e => e.Balance)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentSignUpsFromLastIntervalClaim).HasColumnType("int(11)");

                entity.Property(e => e.ReferalCode)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TotalEarnings)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(20000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpUserRegistrationSessions>(entity =>
            {
                entity.HasKey(e => e.SessionKey)
                    .HasName("PRIMARY");

                entity.ToTable("wp_user_registration_sessions");

                entity.HasIndex(e => e.SessionId)
                    .HasName("session_id")
                    .IsUnique();

                entity.Property(e => e.SessionKey)
                    .HasColumnName("session_key")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.SessionExpiry)
                    .HasColumnName("session_expiry")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SessionValue)
                    .IsRequired()
                    .HasColumnName("session_value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpUsermeta>(entity =>
            {
                entity.HasKey(e => e.UmetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_usermeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.UmetaId)
                    .HasColumnName("umeta_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpUserpaymentsubcriptiondetails>(entity =>
            {
                entity.ToTable("wp_userpaymentsubcriptiondetails");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(255)");

                entity.Property(e => e.AuthorizationCode)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasColumnName("CustomerID")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentReference)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.SubscriptionId)
                    .IsRequired()
                    .HasColumnName("SubscriptionID")
                    .HasMaxLength(20000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpUserreferalsMappings>(entity =>
            {
                entity.ToTable("wp_userreferalsMappings");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(255)");

                entity.Property(e => e.IsAccepted).HasColumnType("bit(1)");

                entity.Property(e => e.ReferedBy)
                    .IsRequired()
                    .HasMaxLength(20000)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredUserId)
                    .HasColumnName("RegisteredUserID")
                    .HasMaxLength(20000)
                    .IsUnicode(false);

                entity.Property(e => e.TotalSubscriptions).HasColumnType("bigint(255)");
            });

            modelBuilder.Entity<WpUsers>(entity =>
            {
                entity.ToTable("wp_users");

                entity.HasIndex(e => e.UserEmail)
                    .HasName("user_email");

                entity.HasIndex(e => e.UserLogin)
                    .HasName("user_login_key");

                entity.HasIndex(e => e.UserNicename)
                    .HasName("user_nicename");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserActivationKey)
                    .IsRequired()
                    .HasColumnName("user_activation_key")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("user_login")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserNicename)
                    .IsRequired()
                    .HasColumnName("user_nicename")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasColumnName("user_pass")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserRegistered)
                    .HasColumnName("user_registered")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.UserStatus)
                    .HasColumnName("user_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserUrl)
                    .IsRequired()
                    .HasColumnName("user_url")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpWcDownloadLog>(entity =>
            {
                entity.HasKey(e => e.DownloadLogId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wc_download_log");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("permission_id");

                entity.HasIndex(e => e.Timestamp)
                    .HasName("timestamp");

                entity.Property(e => e.DownloadLogId)
                    .HasColumnName("download_log_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.UserIpAddress)
                    .HasColumnName("user_ip_address")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpWcProductMetaLookup>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wc_product_meta_lookup");

                entity.HasIndex(e => e.Downloadable)
                    .HasName("downloadable");

                entity.HasIndex(e => e.Onsale)
                    .HasName("onsale");

                entity.HasIndex(e => e.StockQuantity)
                    .HasName("stock_quantity");

                entity.HasIndex(e => e.StockStatus)
                    .HasName("stock_status");

                entity.HasIndex(e => e.Virtual)
                    .HasName("virtual");

                entity.HasIndex(e => new { e.MinPrice, e.MaxPrice })
                    .HasName("min_max_price");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AverageRating)
                    .HasColumnName("average_rating")
                    .HasColumnType("decimal(3,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Downloadable)
                    .HasColumnName("downloadable")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MaxPrice)
                    .HasColumnName("max_price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.MinPrice)
                    .HasColumnName("min_price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Onsale)
                    .HasColumnName("onsale")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RatingCount)
                    .HasColumnName("rating_count")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");

                entity.Property(e => e.StockStatus)
                    .HasColumnName("stock_status")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'instock'");

                entity.Property(e => e.TotalSales)
                    .HasColumnName("total_sales")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Virtual)
                    .HasColumnName("virtual")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<WpWcTaxRateClasses>(entity =>
            {
                entity.HasKey(e => e.TaxRateClassId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wc_tax_rate_classes");

                entity.HasIndex(e => e.Slug)
                    .HasName("slug")
                    .IsUnique();

                entity.Property(e => e.TaxRateClassId)
                    .HasColumnName("tax_rate_class_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpWcWebhooks>(entity =>
            {
                entity.HasKey(e => e.WebhookId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wc_webhooks");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.WebhookId)
                    .HasColumnName("webhook_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ApiVersion)
                    .HasColumnName("api_version")
                    .HasColumnType("smallint(4)");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.DateCreatedGmt)
                    .HasColumnName("date_created_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.DateModified)
                    .HasColumnName("date_modified")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.DateModifiedGmt)
                    .HasColumnName("date_modified_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.DeliveryUrl)
                    .IsRequired()
                    .HasColumnName("delivery_url");

                entity.Property(e => e.FailureCount)
                    .HasColumnName("failure_count")
                    .HasColumnType("smallint(10)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PendingDelivery)
                    .HasColumnName("pending_delivery")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasColumnName("topic")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWcsPaymentRetries>(entity =>
            {
                entity.HasKey(e => e.RetryId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wcs_payment_retries");

                entity.HasIndex(e => e.OrderId)
                    .HasName("order_id");

                entity.Property(e => e.RetryId)
                    .HasColumnName("retry_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.DateGmt)
                    .HasColumnName("date_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.RuleRaw).HasColumnName("rule_raw");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpWoocommerceApiKeys>(entity =>
            {
                entity.HasKey(e => e.KeyId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_api_keys");

                entity.HasIndex(e => e.ConsumerKey)
                    .HasName("consumer_key");

                entity.HasIndex(e => e.ConsumerSecret)
                    .HasName("consumer_secret");

                entity.Property(e => e.KeyId)
                    .HasColumnName("key_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ConsumerKey)
                    .IsRequired()
                    .HasColumnName("consumer_key")
                    .HasMaxLength(64)
                    .IsFixedLength();

                entity.Property(e => e.ConsumerSecret)
                    .IsRequired()
                    .HasColumnName("consumer_secret")
                    .HasMaxLength(43)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastAccess).HasColumnName("last_access");

                entity.Property(e => e.Nonces)
                    .HasColumnName("nonces")
                    .HasColumnType("longtext");

                entity.Property(e => e.Permissions)
                    .IsRequired()
                    .HasColumnName("permissions")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TruncatedKey)
                    .IsRequired()
                    .HasColumnName("truncated_key")
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWoocommerceAttributeTaxonomies>(entity =>
            {
                entity.HasKey(e => e.AttributeId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_attribute_taxonomies");

                entity.HasIndex(e => e.AttributeName)
                    .HasName("attribute_name");

                entity.Property(e => e.AttributeId)
                    .HasColumnName("attribute_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.AttributeLabel)
                    .HasColumnName("attribute_label")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasColumnName("attribute_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeOrderby)
                    .IsRequired()
                    .HasColumnName("attribute_orderby")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AttributePublic)
                    .HasColumnName("attribute_public")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.AttributeType)
                    .IsRequired()
                    .HasColumnName("attribute_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpWoocommerceDownloadableProductPermissions>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_downloadable_product_permissions");

                entity.HasIndex(e => e.OrderId)
                    .HasName("order_id");

                entity.HasIndex(e => new { e.DownloadId, e.OrderId, e.ProductId })
                    .HasName("download_order_product");

                entity.HasIndex(e => new { e.ProductId, e.OrderId, e.OrderKey, e.DownloadId })
                    .HasName("download_order_key_product");

                entity.HasIndex(e => new { e.UserId, e.OrderId, e.DownloadsRemaining, e.AccessExpires })
                    .HasName("user_order_remaining_expires");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.AccessExpires).HasColumnName("access_expires");

                entity.Property(e => e.AccessGranted)
                    .HasColumnName("access_granted")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.DownloadCount)
                    .HasColumnName("download_count")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.DownloadId)
                    .IsRequired()
                    .HasColumnName("download_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DownloadsRemaining)
                    .HasColumnName("downloads_remaining")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.OrderKey)
                    .IsRequired()
                    .HasColumnName("order_key")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWoocommerceLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_log");

                entity.HasIndex(e => e.Level)
                    .HasName("level");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Context)
                    .HasColumnName("context")
                    .HasColumnType("longtext");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("smallint(4)");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("longtext");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            });

            modelBuilder.Entity<WpWoocommerceOrderItemmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_order_itemmeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.OrderItemId)
                    .HasName("order_item_id");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.OrderItemId)
                    .HasColumnName("order_item_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWoocommerceOrderItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_order_items");

                entity.HasIndex(e => e.OrderId)
                    .HasName("order_id");

                entity.Property(e => e.OrderItemId)
                    .HasColumnName("order_item_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.OrderItemName)
                    .IsRequired()
                    .HasColumnName("order_item_name");

                entity.Property(e => e.OrderItemType)
                    .IsRequired()
                    .HasColumnName("order_item_type")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpWoocommercePaymentTokenmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_payment_tokenmeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.PaymentTokenId)
                    .HasName("payment_token_id");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.PaymentTokenId)
                    .HasColumnName("payment_token_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWoocommercePaymentTokens>(entity =>
            {
                entity.HasKey(e => e.TokenId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_payment_tokens");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.TokenId)
                    .HasColumnName("token_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.GatewayId)
                    .IsRequired()
                    .HasColumnName("gateway_id")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsDefault)
                    .HasColumnName("is_default")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWoocommerceSessions>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_sessions");

                entity.HasIndex(e => e.SessionKey)
                    .HasName("session_key")
                    .IsUnique();

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.SessionExpiry)
                    .HasColumnName("session_expiry")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.SessionKey)
                    .IsRequired()
                    .HasColumnName("session_key")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.SessionValue)
                    .IsRequired()
                    .HasColumnName("session_value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpWoocommerceShippingZoneLocations>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_shipping_zone_locations");

                entity.HasIndex(e => e.LocationId)
                    .HasName("location_id");

                entity.HasIndex(e => new { e.LocationType, e.LocationCode })
                    .HasName("location_type_code");

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasColumnName("location_code")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LocationType)
                    .IsRequired()
                    .HasColumnName("location_type")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWoocommerceShippingZoneMethods>(entity =>
            {
                entity.HasKey(e => e.InstanceId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_shipping_zone_methods");

                entity.Property(e => e.InstanceId)
                    .HasColumnName("instance_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MethodId)
                    .IsRequired()
                    .HasColumnName("method_id")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MethodOrder)
                    .HasColumnName("method_order")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWoocommerceShippingZones>(entity =>
            {
                entity.HasKey(e => e.ZoneId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_shipping_zones");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ZoneName)
                    .IsRequired()
                    .HasColumnName("zone_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneOrder)
                    .HasColumnName("zone_order")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWoocommerceTaxRateLocations>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_tax_rate_locations");

                entity.HasIndex(e => e.TaxRateId)
                    .HasName("tax_rate_id");

                entity.HasIndex(e => new { e.LocationType, e.LocationCode })
                    .HasName("location_type_code");

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasColumnName("location_code")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LocationType)
                    .IsRequired()
                    .HasColumnName("location_type")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TaxRateId)
                    .HasColumnName("tax_rate_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpWoocommerceTaxRates>(entity =>
            {
                entity.HasKey(e => e.TaxRateId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_woocommerce_tax_rates");

                entity.HasIndex(e => e.TaxRateClass)
                    .HasName("tax_rate_class");

                entity.HasIndex(e => e.TaxRateCountry)
                    .HasName("tax_rate_country");

                entity.HasIndex(e => e.TaxRatePriority)
                    .HasName("tax_rate_priority");

                entity.HasIndex(e => e.TaxRateState)
                    .HasName("tax_rate_state");

                entity.Property(e => e.TaxRateId)
                    .HasColumnName("tax_rate_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.TaxRate)
                    .IsRequired()
                    .HasColumnName("tax_rate")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TaxRateClass)
                    .IsRequired()
                    .HasColumnName("tax_rate_class")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TaxRateCompound)
                    .HasColumnName("tax_rate_compound")
                    .HasColumnType("int(1)");

                entity.Property(e => e.TaxRateCountry)
                    .IsRequired()
                    .HasColumnName("tax_rate_country")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TaxRateName)
                    .IsRequired()
                    .HasColumnName("tax_rate_name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TaxRateOrder)
                    .HasColumnName("tax_rate_order")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.TaxRatePriority)
                    .HasColumnName("tax_rate_priority")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.TaxRateShipping)
                    .HasColumnName("tax_rate_shipping")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TaxRateState)
                    .IsRequired()
                    .HasColumnName("tax_rate_state")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<WpWpfmBackup>(entity =>
            {
                entity.ToTable("wp_wpfm_backup");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BackupDate).HasColumnName("backup_date");

                entity.Property(e => e.BackupName).HasColumnName("backup_name");
            });

            modelBuilder.Entity<WpWpformsEntries>(entity =>
            {
                entity.HasKey(e => e.EntryId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_wpforms_entries");

                entity.HasIndex(e => e.FormId)
                    .HasName("form_id");

                entity.Property(e => e.EntryId)
                    .HasColumnName("entry_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.DateModified).HasColumnName("date_modified");

                entity.Property(e => e.Fields)
                    .IsRequired()
                    .HasColumnName("fields")
                    .HasColumnType("longtext");

                entity.Property(e => e.FormId)
                    .HasColumnName("form_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("ip_address")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Meta)
                    .IsRequired()
                    .HasColumnName("meta")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Starred)
                    .HasColumnName("starred")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserAgent)
                    .IsRequired()
                    .HasColumnName("user_agent")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UserUuid)
                    .IsRequired()
                    .HasColumnName("user_uuid")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Viewed)
                    .HasColumnName("viewed")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<WpWpformsEntryFields>(entity =>
            {
                entity.ToTable("wp_wpforms_entry_fields");

                entity.HasIndex(e => e.EntryId)
                    .HasName("entry_id");

                entity.HasIndex(e => e.FieldId)
                    .HasName("field_id");

                entity.HasIndex(e => e.FormId)
                    .HasName("form_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.EntryId)
                    .HasColumnName("entry_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FieldId)
                    .HasColumnName("field_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FormId)
                    .HasColumnName("form_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpWpformsEntryMeta>(entity =>
            {
                entity.ToTable("wp_wpforms_entry_meta");

                entity.HasIndex(e => e.EntryId)
                    .HasName("entry_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("longtext");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.EntryId)
                    .HasColumnName("entry_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FormId)
                    .HasColumnName("form_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<WpYoastSeoLinks>(entity =>
            {
                entity.ToTable("wp_yoast_seo_links");

                entity.HasIndex(e => new { e.PostId, e.Type })
                    .HasName("link_direction");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.TargetPostId)
                    .HasColumnName("target_post_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WpYoastSeoMeta>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wp_yoast_seo_meta");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("object_id")
                    .IsUnique();

                entity.Property(e => e.IncomingLinkCount)
                    .HasColumnName("incoming_link_count")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.InternalLinkCount)
                    .HasColumnName("internal_link_count")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("object_id")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WpZohocustomerMapping>(entity =>
            {
                entity.ToTable("wp_zohocustomer_mapping");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(255)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("bigint(255)");

                entity.Property(e => e.ZohoCustomerId)
                    .HasColumnName("ZohoCustomerID")
                    .HasMaxLength(20000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
