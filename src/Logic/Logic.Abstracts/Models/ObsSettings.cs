// ReSharper disable UnusedMember.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace codingfreaks.obscene.Logic.Abstracts.Models
{
    public class ObsSettings
{
    public string name { get; set; }
    public DesktopAudioDevice1 DesktopAudioDevice1 { get; set; }
    public AuxAudioDevice1 AuxAudioDevice1 { get; set; }
    public object[] groups { get; set; }
    public Scene_order[] scene_order { get; set; }
    public string current_scene { get; set; }
    public string current_program_scene { get; set; }
    public object[] canvases { get; set; }
    public string current_transition { get; set; }
    public int transition_duration { get; set; }
    public Transitions[] transitions { get; set; }
    public Quick_transitions[] quick_transitions { get; set; }
    public object[] saved_projectors { get; set; }
    public bool preview_locked { get; set; }
    public bool scaling_enabled { get; set; }
    public int scaling_level { get; set; }
    public double scaling_off_x { get; set; }
    public double scaling_off_y { get; set; }
    public Virtual_camera virtual_camera { get; set; }
    public Modules modules { get; set; }
    public Resolution resolution { get; set; }
    public int version { get; set; }
    public Sources[] sources { get; set; }
}

public class DesktopAudioDevice1
{
    public int prev_ver { get; set; }
    public string name { get; set; }
    public string uuid { get; set; }
    public string id { get; set; }
    public string versioned_id { get; set; }
    public Settings settings { get; set; }
    public int mixers { get; set; }
    public int sync { get; set; }
    public int flags { get; set; }
    public double volume { get; set; }
    public double balance { get; set; }
    public bool enabled { get; set; }
    public bool muted { get; set; }
    public bool push_to_mute { get; set; }
    public int push_to_mute_delay { get; set; }
    public bool push_to_talk { get; set; }
    public int push_to_talk_delay { get; set; }
    public Hotkeys hotkeys { get; set; }
    public int deinterlace_mode { get; set; }
    public int deinterlace_field_order { get; set; }
    public int monitoring_type { get; set; }
    public Private_settings private_settings { get; set; }
}

public class Settings
{
    public string device_id { get; set; }
}

public class Hotkeys
{
    public object[] libobs_mute { get; set; }
    public object[] libobs_unmute { get; set; }
    public object[] libobs_push_to_mute { get; set; }
    public object[] libobs_push_to_talk { get; set; }
}

public class Private_settings
{

}

public class AuxAudioDevice1
{
    public int prev_ver { get; set; }
    public string name { get; set; }
    public string uuid { get; set; }
    public string id { get; set; }
    public string versioned_id { get; set; }
    public Settings1 settings { get; set; }
    public int mixers { get; set; }
    public int sync { get; set; }
    public int flags { get; set; }
    public double volume { get; set; }
    public double balance { get; set; }
    public bool enabled { get; set; }
    public bool muted { get; set; }
    public bool push_to_mute { get; set; }
    public int push_to_mute_delay { get; set; }
    public bool push_to_talk { get; set; }
    public int push_to_talk_delay { get; set; }
    public Hotkeys1 hotkeys { get; set; }
    public int deinterlace_mode { get; set; }
    public int deinterlace_field_order { get; set; }
    public int monitoring_type { get; set; }
    public Private_settings1 private_settings { get; set; }
}

public class Settings1
{
    public string device_id { get; set; }
}

public class Hotkeys1
{
    public object[] libobs_mute { get; set; }
    public object[] libobs_unmute { get; set; }
    public object[] libobs_push_to_mute { get; set; }
    public object[] libobs_push_to_talk { get; set; }
}

public class Private_settings1
{

}

public class Scene_order
{
    public string name { get; set; }
}

public class Transitions
{
    public string name { get; set; }
    public string id { get; set; }
    public Settings2 settings { get; set; }
}

public class Settings2
{
    public string direction { get; set; }
}

public class Quick_transitions
{

    public string name { get; set; }
    public int duration { get; set; }
    public object[] hotkeys { get; set; }
    public int id { get; set; }
    public bool fade_to_black { get; set; }
}

public class Virtual_camera
{
    public int type2 { get; set; }
}

public class Modules
{
    public object[] scripts_tool { get; set; }
    public Output_timer output_timer { get; set; }
    public Auto_scene_switcher auto_scene_switcher { get; set; }
    public Captions captions { get; set; }
}

public class Output_timer
{
    public int streamTimerHours { get; set; }
    public int streamTimerMinutes { get; set; }
    public int streamTimerSeconds { get; set; }
    public int recordTimerHours { get; set; }
    public int recordTimerMinutes { get; set; }
    public int recordTimerSeconds { get; set; }
    public bool autoStartStreamTimer { get; set; }
    public bool autoStartRecordTimer { get; set; }
    public bool pauseRecordTimer { get; set; }
}

public class Auto_scene_switcher
{
    public int interval { get; set; }
    public string non_matching_scene { get; set; }
    public bool switch_if_not_matching { get; set; }
    public bool active { get; set; }
    public object[] switches { get; set; }
}

public class Captions
{
    public string source { get; set; }
    public bool enabled { get; set; }
    public int lang_id { get; set; }
    public string provider { get; set; }
}

public class Resolution
{
    public int x { get; set; }
    public int y { get; set; }
}

public class Sources
{
    public int prev_ver { get; set; }
    public string name { get; set; }
    public string uuid { get; set; }
    public string id { get; set; }
    public string versioned_id { get; set; }
    public Settings3 settings { get; set; }
    public int mixers { get; set; }
    public int sync { get; set; }
    public int flags { get; set; }
    public double volume { get; set; }
    public double balance { get; set; }
    public bool enabled { get; set; }
    public bool muted { get; set; }
    public bool push_to_mute { get; set; }
    public int push_to_mute_delay { get; set; }
    public bool push_to_talk { get; set; }
    public int push_to_talk_delay { get; set; }
    public Hotkeys2 hotkeys { get; set; }
    public int deinterlace_mode { get; set; }
    public int deinterlace_field_order { get; set; }
    public int monitoring_type { get; set; }
    public string canvas_uuid { get; set; }
    public Private_settings2 private_settings { get; set; }
    public Filters[] filters { get; set; }
}

public class Settings3
{
    public int id_counter { get; set; }
    public bool custom_size { get; set; }
    public Items[] items { get; set; }
    public string monitor_id { get; set; }
    public string resolution { get; set; }
    public string last_resolution { get; set; }
    public bool deactivate_when_not_showing { get; set; }
    public string video_device_id { get; set; }
    public string last_video_device_id { get; set; }
    public string undo_uuid { get; set; }
    public int frame_interval { get; set; }
    public int res_type { get; set; }
    public int video_format { get; set; }
    public bool active { get; set; }
    public string file { get; set; }
    public string device_id { get; set; }
    public bool use_device_timing { get; set; }
}

public class Items
{
    public string name { get; set; }
    public string source_uuid { get; set; }
    public bool visible { get; set; }
    public bool locked { get; set; }
    public double rot { get; set; }
    public Scale_ref scale_ref { get; set; }
    public int align { get; set; }
    public int bounds_type { get; set; }
    public int bounds_align { get; set; }
    public bool bounds_crop { get; set; }
    public int crop_left { get; set; }
    public int crop_top { get; set; }
    public int crop_right { get; set; }
    public int crop_bottom { get; set; }
    public int id { get; set; }
    public bool group_item_backup { get; set; }
    public Pos pos { get; set; }
    public Pos_rel pos_rel { get; set; }
    public Scale scale { get; set; }
    public Scale_rel scale_rel { get; set; }
    public Bounds bounds { get; set; }
    public Bounds_rel bounds_rel { get; set; }
    public string scale_filter { get; set; }
    public string blend_method { get; set; }
    public string blend_type { get; set; }
    public Show_transition show_transition { get; set; }
    public Hide_transition hide_transition { get; set; }
    public Private_settings3 private_settings { get; set; }
}

public class Scale_ref
{
    public double x { get; set; }
    public double y { get; set; }
}

public class Pos
{
    public double x { get; set; }
    public double y { get; set; }
}

public class Pos_rel
{
    public double x { get; set; }
    public double y { get; set; }
}

public class Scale
{
    public double x { get; set; }
    public double y { get; set; }
}

public class Scale_rel
{
    public double x { get; set; }
    public double y { get; set; }
}

public class Bounds
{
    public double x { get; set; }
    public double y { get; set; }
}

public class Bounds_rel
{
    public double x { get; set; }
    public double y { get; set; }
}

public class Show_transition
{
    public int duration { get; set; }
}

public class Hide_transition
{
    public int duration { get; set; }
}

public class Private_settings3
{

}

public class Hotkeys2
{
    public object[] OBSBasic_SelectScene { get; set; }
    public object[] libobs_show_scene_item_1 { get; set; }
    public object[] libobs_hide_scene_item_1 { get; set; }
    public object[] libobs_show_scene_item_5 { get; set; }
    public object[] libobs_hide_scene_item_5 { get; set; }
    public object[] libobs_show_scene_item_4 { get; set; }
    public object[] libobs_hide_scene_item_4 { get; set; }
    public object[] libobs_show_scene_item_2 { get; set; }
    public object[] libobs_hide_scene_item_2 { get; set; }
    public object[] libobs_show_scene_item_6 { get; set; }
    public object[] libobs_hide_scene_item_6 { get; set; }
    public object[] libobs_show_scene_item_3 { get; set; }
    public object[] libobs_hide_scene_item_3 { get; set; }
    public object[] libobs_mute { get; set; }
    public object[] libobs_unmute { get; set; }
    public object[] libobs_push_to_mute { get; set; }
    public object[] libobs_push_to_talk { get; set; }
    public object[] libobs_show_scene_item_8 { get; set; }
    public object[] libobs_hide_scene_item_8 { get; set; }
    public object[] libobs_show_scene_item_12 { get; set; }
    public object[] libobs_hide_scene_item_12 { get; set; }
}

public class Private_settings2
{

}

public class Filters
{
    public int prev_ver { get; set; }
    public string name { get; set; }
    public string uuid { get; set; }
    public string id { get; set; }
    public string versioned_id { get; set; }
    public Settings4 settings { get; set; }
    public int mixers { get; set; }
    public int sync { get; set; }
    public int flags { get; set; }
    public double volume { get; set; }
    public double balance { get; set; }
    public bool enabled { get; set; }
    public bool muted { get; set; }
    public bool push_to_mute { get; set; }
    public int push_to_mute_delay { get; set; }
    public bool push_to_talk { get; set; }
    public int push_to_talk_delay { get; set; }
    public Hotkeys3 hotkeys { get; set; }
    public int deinterlace_mode { get; set; }
    public int deinterlace_field_order { get; set; }
    public int monitoring_type { get; set; }
    public Private_settings4 private_settings { get; set; }
}

public class Settings4
{
    public double contrast { get; set; }
    public double saturation { get; set; }
    public string plugin_path { get; set; }
    public string chunk_data { get; set; }
    public string chunk_hash { get; set; }
    public double low { get; set; }
    public double mid { get; set; }
    public double high { get; set; }
    public double ratio { get; set; }
    public double threshold { get; set; }
    public double output_gain { get; set; }
    public int cx { get; set; }
    public int cy { get; set; }
    public bool relative { get; set; }
    public string image_path { get; set; }
}

public class Hotkeys3
{

}

public class Private_settings4
{

}


}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
