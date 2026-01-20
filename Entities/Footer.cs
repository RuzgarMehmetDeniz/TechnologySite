namespace TechnologySite.Entities
{
    public class Footer
    {
        public int FooterID { get; set; }
        public string? Image {  get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string? LocationTitle {  get; set; }
        public string Location {  get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TikTokUrl { get; set; }
        public string YouTubeUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string WhatsAppUrl { get; set; }
        public string TelegramUrl { get; set; }
        public string RedditUrl { get; set; }
        public string DiscordUrl { get; set; }
        public string XUrl { get; set; }
        public string SnapchatUrl { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
